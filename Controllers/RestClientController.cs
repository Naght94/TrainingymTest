using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Trainingym.Bussines.Interface;
using Trainingym.DTO;
using Trainingym.Models;

namespace Trainingym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestClientController : ControllerBase
    {
        private readonly IRestClientLocal _restClient;

        public RestClientController(IRestClientLocal restClient)
        {
            _restClient = restClient;
        }

        //// GET: api/Top3IdWithMoreComments
        [HttpGet ("Top3IdWithMoreComments")]
        public async Task<ActionResult<IEnumerable<List<ApiCallDTO>>>> Top3IdWithMoreComments()
        {
            return Ok(_restClient.Top3IdWithMoreComments());
        }

        //// GET: api/Top3IdWithMoreComments
        [HttpGet("Top3PostWithMoreComments")]
        public async Task<ActionResult<IEnumerable<List<TopCommentDTO>>>> Top3PostWithMoreComments()
        {
            return Ok(_restClient.Top3PostWithMoreComments());
        }

    }
}
