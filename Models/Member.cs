using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using Trainingym.Context;

namespace Trainingym.Models;

public partial class Member
{
    public long MemberId { get; set; }

    public string MemberName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}