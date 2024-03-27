using System.ComponentModel.DataAnnotations;

namespace Trainingym.DTO
{
    public class CreateProductDTO
    {
        [MaxLength(500)]
        public string ProductName { get; set; } = null!;
    }
}
