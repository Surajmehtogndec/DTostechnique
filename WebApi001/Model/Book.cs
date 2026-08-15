using System;
using System.Collections.Generic;

namespace WebApi001.Model;

public partial class Book
{
    public int BookId { get; set; }

    public string Isbn { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int AuthorId { get; set; }

    public int CategoryId { get; set; }

    public int? PublisherId { get; set; }

    public int? PublicationYear { get; set; }

    public int TotalCopies { get; set; }

    public int AvailableCopies { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual ICollection<Bookissue> Bookissues { get; set; } = new List<Bookissue>();

    public virtual Category Category { get; set; } = null!;

    public virtual Publisher? Publisher { get; set; }
}
