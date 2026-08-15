using System;
using System.Collections.Generic;

namespace WebApi001.Model;

public partial class Bookreturn
{
    public int ReturnId { get; set; }

    public int IssueId { get; set; }

    public DateTime ReturnDate { get; set; }

    public string? Condition { get; set; }

    public string? Remarks { get; set; }

    public virtual Bookissue Issue { get; set; } = null!;
}
