using System.ComponentModel.DataAnnotations;

namespace Trainingym.DTO
{
    public class ReadMemberDTO
    {
        public long Id { get; set; }
        [MaxLength(500)]
        public string MemberName { get; set; } = null!;
    }
}
