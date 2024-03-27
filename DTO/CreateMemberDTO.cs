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
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Characters are not allowed.")]
    [MaxLength(500)]
    public string MemberName { get; set; } = null!;
}