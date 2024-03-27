using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trainingym.Bussines.Interface;
using Trainingym.Context;
using Trainingym.DTO;
using Trainingym.Models;

namespace Trainingym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _product;

        public ProductsController(IProduct product)
        {
            _product = product;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadProductDTO>>> GetProducts()
        {
            IEnumerable<Product> products = await _product.GetAllProductsAsync();
            List<ReadProductDTO> productDTO = new List<ReadProductDTO>();
            foreach (var item in products)
            {
                ReadProductDTO product = new ReadProductDTO()
                {
                    Id = item.ProductId,
                    ProductName = item.ProductName
                };
                productDTO.Add(product);
            }
            return Ok(productDTO);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            Product product = await _product.GetProductById(id);
            if (product != null)
            {
                ReadProductDTO productDto = new ReadProductDTO()
                {
                    Id = product.ProductId,
                    ProductName = product.ProductName
                };

                return Ok(productDto);
            }
            return BadRequest("Product not found/Product no encontrado");
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(long id, UpdateProductDTO product)
        {
            Product productDB = await _product.UpdateProductAsync(id, product);
            if (productDB == null)
            {
                return BadRequest("Id not found");
            }

            return Ok(productDB);
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(CreateProductDTO product)
        {
            await _product.CreaterProduct(product);
            return Ok(CreatedAtAction("New product created", product.ProductName));
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            await _product.DeleteProduct(id);
            return NoContent();
        }

        
    }
}
