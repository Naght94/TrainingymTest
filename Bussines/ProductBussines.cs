using Microsoft.EntityFrameworkCore;
using Trainingym.Bussines.Interface;
using Trainingym.Context;
using Trainingym.DTO;
using Trainingym.Models;

namespace Trainingym.Bussines
{
    public class ProductBussines : IProduct
    {
        private readonly TrainingymContext _context;
        public ProductBussines(TrainingymContext context)
        {
            _context = context;
        }

        public async Task<Product> CreaterProduct(CreateProductDTO productDTO)
        {
            Product product = new() { ProductName = productDTO.ProductName };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProduct(long id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

            return null;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(long id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task<Product> UpdateProductAsync(long id, UpdateProductDTO product)
        {
            var productDB = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            productDB.ProductName = product.ProductName;
            await _context.SaveChangesAsync();

            return productDB;
        }
    }
}
