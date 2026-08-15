using System;
using System.Collections.Generic;

namespace WebApi001.Model;

public partial class Fine
{
    public int FineId { get; set; }

    public int IssueId { get; set; }

    public decimal FineAmount { get; set; }

    public decimal PaidAmount { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Bookissue Issue { get; set; } = null!;
}
