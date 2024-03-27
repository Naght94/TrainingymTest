using System.ComponentModel.DataAnnotations;

namespace Trainingym.DTO
{
    public class UpdateProductDTO
    {
        [Required]
        [MaxLength(500)]
        public string ProductName { get; set; } = null!;
    }
}
