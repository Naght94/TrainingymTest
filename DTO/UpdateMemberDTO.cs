using System.ComponentModel.DataAnnotations;

namespace Trainingym.DTO
{
    public class UpdateMemberDTO
    {
        
        [Required]
        [MaxLength(500)]
        public string MemberName { get; set; } = null!;
    }
}
