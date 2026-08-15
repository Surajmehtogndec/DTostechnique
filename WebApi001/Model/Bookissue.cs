using System;
using System.Collections.Generic;

namespace WebApi001.Model;

public partial class Bookissue
{
    public int IssueId { get; set; }

    public int BookId { get; set; }

    public int MemberId { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime DueDate { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Bookreturn? Bookreturn { get; set; }

    public virtual ICollection<Fine> Fines { get; set; } = new List<Fine>();

    public virtual Member Member { get; set; } = null!;
}
