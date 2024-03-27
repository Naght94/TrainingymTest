using System.ComponentModel.DataAnnotations;

namespace Trainingym.DTO
{
    public class ReadProductDTO
    {
        public long Id { get; set; }
        [MaxLength(500)]
        public string ProductName { get; set; } = null!;
    }
}
