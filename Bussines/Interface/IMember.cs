using Microsoft.AspNetCore.Mvc;
using Trainingym.DTO;
using Trainingym.Models;
namespace Trainingym.Bussines.Interface
{
    public interface IMember
    {
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task<Member> GetMemberById(long id);
        Task<Member> UpdateMemberAsync(long id, UpdateMemberDTO member);
        Task<Member> CreaterMember(CreateMemberDTO memberDTO);
        Task<Member> DeleteMember(long id);
    }
}
