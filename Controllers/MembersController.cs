using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trainingym.Bussines;
using Trainingym.Bussines.Interface;
using Trainingym.Context;
using Trainingym.DTO;
using Trainingym.Models;

namespace Trainingym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        
        private readonly IMember _member;

        public MembersController(IMember member)
        {
            _member = member;
        }

        //// GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadMemberDTO>>> GetMembers()
        {
            IEnumerable<Member> members = await _member.GetAllMembersAsync();
            List<ReadMemberDTO> membersDTO = new List<ReadMemberDTO>();
            foreach (var item in members)
            {
                ReadMemberDTO member = new ReadMemberDTO() {
                Id = item.MemberId,
                MemberName = item.MemberName
                };
                membersDTO.Add(member);
            }
            return Ok(membersDTO);
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadMemberDTO>> GetMember(long id)
        {
            Member member = await _member.GetMemberById(id);
            if (member != null)
            {
                ReadMemberDTO memberDto = new ReadMemberDTO()
                {
                    Id = member.MemberId,
                    MemberName = member.MemberName
                };

                return Ok(memberDto);
            }
            return BadRequest("Member not found/Miembro no encontrado");
        }

        //// PUT: api/Members/5
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(long id, UpdateMemberDTO member)
        {
            Member memberDB = await _member.UpdateMemberAsync(id, member);
            if (memberDB == null)
            {
                return BadRequest("Id not found");
            }
            
            return Ok(memberDB);
            
        }

        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(CreateMemberDTO member)
        {
            await _member.CreaterMember(member);
            return Ok(CreatedAtAction("Welcome new member", member.MemberName));
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(long id)
        {
            await _member.DeleteMember(id);
            return NoContent();
        }
    }
}
