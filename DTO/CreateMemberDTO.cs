using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using Trainingym.Context;

namespace Trainingym.DTO;

public partial class CreateMemberDTO
{
    //[RegularExpression("[a-zA-Z]", ErrorMessage = "only alphabet")]
    [MaxLength(500)]
    public string MemberName { get; set; } = null!;
}