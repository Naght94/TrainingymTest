using Trainingym.DTO;
using Trainingym.Models;

namespace Trainingym.Bussines.Interface
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductById(long id);
        Task<Product> UpdateProductAsync(long id, UpdateProductDTO member);
        Task<Product> CreaterProduct(CreateProductDTO memberDTO);
        Task<Product> DeleteProduct(long id);
    }
}
