using System.Net;
using Trainingym.Bussines.Interface;
using Trainingym.DTO;
using static System.Net.WebRequestMethods;
using RestSharp;
using Azure.Core;
using System.Collections.Immutable;
using Newtonsoft.Json;
using System.Linq;
using System.Xml.Linq;

namespace Trainingym.Bussines
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE,
    }

    public class RestClientBussines : IRestClientLocal
    {
        

        public async Task<IEnumerable<int>> Top3IdWithMoreComments()
        {
            var list = Makerequest();
            var topThreePostIds = list.Result
                                  .GroupBy(c => c.postId)
                                  .OrderByDescending(g => g.Count())
                                  .Take(3)
                                  .Select(g => g.Key)
                                  .ToList();

            return topThreePostIds;
        }

        public async Task<IEnumerable<TopCommentDTO>> Top3PostWithMoreComments()
        {
            var list = Makerequest();
            var topThreePostIds = list.Result
                                  .GroupBy(c => c.postId)
                                  .OrderByDescending(g => g.Count())
                                  .Take(3)
                                  .Select(g => g.Key)
                                  .ToList();

            List<TopCommentDTO> result = new List<TopCommentDTO>();
            foreach (var item in topThreePostIds)
            {
                var comment = list.Result.Where(p => p.postId == item);
                TopCommentDTO topComment = new()
                {
                    Id = item,
                    commentCount = comment.Count(),

                };
                result.Add(topComment);
            }
            return result;
        }

        public async Task<IEnumerable<ApiCallDTO>> Makerequest()
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://jsonplaceholder.typicode.com/comments");
                var result = await client.GetAsync(endpoint);
                var json = result.Content.ReadAsStringAsync().Result;
                List<ApiCallDTO> apiCallDTOs = JsonConvert.DeserializeObject<List<ApiCallDTO>>(json);
                return apiCallDTOs;
            }
            throw new ArgumentException("Error with the api from jsonplaceholder");
        }

        
    }

}
