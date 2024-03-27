using System.ComponentModel.DataAnnotations;

namespace Trainingym.DTO
{
    public class UpdateMemberDTO
    {
        
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Characters are not allowed.")]
        [MaxLength(500)]
        public string MemberName { get; set; } = null!;
    }
}
