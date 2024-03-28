using System.ComponentModel.DataAnnotations;

namespace Trainingym.DTO
{
    public class OrderCreateDTO
    {
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public long productId { get; set; }
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public long memberId { get; set; }
    }
}
