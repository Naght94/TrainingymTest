using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trainingym.Bussines.Interface;
using Trainingym.DTO;
using Trainingym.Models;

namespace Trainingym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrder _order;

        public OrderController(IOrder order)
        {
            _order = order;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadProductDTO>>> GetLastOrders()
        {
            return Ok(_order.GetLastMemberOrder());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ReadProductDTO>>> GetLastOrdersById(long id)
        {
            var order = _order.GetLastMemberOrderById(id);
            if (order.Count > 0)
            {
                return Ok(order);
            }
            return BadRequest("Id not found");
        }

        [HttpPost]
        public async Task<ActionResult<OrderReadDTO>> PostOrder(OrderCreateDTO product)
        {
            OrderReadDTO order = await _order.CreaterOrder(product);
            if (order != null)
            {
                return Ok(order);
            }
            return BadRequest("");
        }
    }
}
