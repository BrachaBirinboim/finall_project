using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Client
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string Kind { get; set; }

    public DateTime BirthDate { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
}
