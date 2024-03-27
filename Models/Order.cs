using System;
using System.Collections.Generic;

namespace Trainingym.Models;

public partial class Order
{
    public long OrderId { get; set; }

    public long FkMemberid { get; set; }

    public long FkProductid { get; set; }

    public DateTime OrderDateorder { get; set; }

    public virtual Member FkMember { get; set; } = null!;

    public virtual Product FkProduct { get; set; } = null!;
}
