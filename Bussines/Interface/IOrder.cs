using Trainingym.DTO;
using Trainingym.Models;

namespace Trainingym.Bussines.Interface
{
    public interface IOrder
    {
        List<LastOrderDTO> GetLastMemberOrderById(long memberId);
        Task<OrderReadDTO> CreaterOrder(OrderCreateDTO memberDTO);
        public List<LastOrderDTO> GetLastMemberOrder();
    }
}
