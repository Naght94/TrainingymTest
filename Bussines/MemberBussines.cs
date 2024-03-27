using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Trainingym.Bussines.Interface;
using Trainingym.Context;
using Trainingym.DTO;
using Trainingym.Models;

namespace Trainingym.Bussines
{
    public class MemberBussines : IMember
    {
        private readonly TrainingymContext _context;
        public MemberBussines(TrainingymContext context)
        {
            _context = context;
        }

        public async Task<Member> CreaterMember(CreateMemberDTO memberDTO)
        {
            Member member = new() { MemberName = memberDTO.MemberName };
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<Member> DeleteMember(long id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync(); 
            }

            return null;
        }

        public async Task<Member> UpdateMemberAsync(long id, UpdateMemberDTO member)
        {
            var memberDB = await _context.Members.FindAsync(id); 
            if (member == null)
            {
                return null;
            }
            memberDB.MemberName = member.MemberName;
            await _context.SaveChangesAsync();

            return memberDB;
        }

        async Task<IEnumerable<Member>> IMember.GetAllMembersAsync()
        {
            return await _context.Members.ToListAsync();
        }

        async Task<Member> IMember.GetMemberById(long id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return null;
            }

            return member;
        }
    }
}
