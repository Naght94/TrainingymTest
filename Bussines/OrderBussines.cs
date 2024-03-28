using Microsoft.EntityFrameworkCore;
using Trainingym.Bussines.Interface;
using Trainingym.Context;
using Trainingym.DTO;
using Trainingym.Models;

namespace Trainingym.Bussines
{
    public class OrderBussines: IOrder
    {
        private readonly TrainingymContext _context;
        
        public OrderBussines(TrainingymContext context)
        {
            _context = context;
        }

        public async Task<OrderReadDTO> CreaterOrder(OrderCreateDTO memberDTO)
        {
            DateTime dateNow = DateTime.Now; //ToString("yyyy-MM-dd HH:mm:ss"),
            var member = await _context.Members.FirstOrDefaultAsync(p => p.MemberId == memberDTO.memberId);
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == memberDTO.productId);
            if (member == null) {
                throw new ArgumentException("Member id not found");
            }
            if (product == null)
            {
                throw new ArgumentException("Product id not found");
            }
            Order newOrder = new Order ()
            {
                OrderDateorder = DateTime.Now,
                FkMemberid = member.MemberId,
                FkMember = member,
                FkProductid = product.ProductId, 
                FkProduct = product 
            };
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
            OrderReadDTO orderReadDTO = new OrderReadDTO() 
            {
                member = newOrder.FkMember.MemberName,
                product = newOrder.FkProduct.ProductName,
                orderDateorder = dateNow
            };
            return orderReadDTO;
        }

        public List<LastOrderDTO> GetLastMemberOrder()
        {
            var lastMemberOrders = _context.Orders
            .GroupBy(o => o.FkMemberid)
            .Select(group => new LastOrderDTO
            {
                member = group.First().FkMember.MemberName,
                product = group.OrderByDescending(o => o.OrderDateorder).First().FkProduct.ProductName,
                orderDateorder = group.OrderByDescending(o => o.OrderDateorder).First().OrderDateorder
            })
            .ToList();

            return lastMemberOrders;

        }

        public List<LastOrderDTO> GetLastMemberOrderById(long memberId)
        {
            try
            {
                var lastMemberOrders = _context.Orders
            .Where(p => p.FkMemberid == memberId)
            .GroupBy(o => o.FkMemberid)
            .Select(group => new LastOrderDTO
            {
                member = group.First().FkMember.MemberName,
                product = group.OrderByDescending(o => o.OrderDateorder).First().FkProduct.ProductName,
                orderDateorder = group.OrderByDescending(o => o.OrderDateorder).First().OrderDateorder
            })
            .ToList();
                return lastMemberOrders;
            }
            catch (Exception)
            {

                return null;
            }
            

        }
    }
}
