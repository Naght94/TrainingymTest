using System;
using System.Collections.Generic;

namespace Trainingym.Models;

public partial class Member
{
    public long MemberId { get; set; }

    public string MemberName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
