using System;
using System.Collections.Generic;

namespace WebApi001.Model;

public partial class Member
{
    public int MemberId { get; set; }

    public string MembershipNumber { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string MembershipType { get; set; } = null!;

    public DateOnly RegistrationDate { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Bookissue> Bookissues { get; set; } = new List<Bookissue>();
}
