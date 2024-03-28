using Trainingym.DTO;
using Trainingym.Models;

namespace Trainingym.Bussines.Interface
{
    public interface IRestClientLocal
    {
        Task<IEnumerable<int>> Top3IdWithMoreComments();
        Task<IEnumerable<TopCommentDTO>> Top3PostWithMoreComments();

    }
}
