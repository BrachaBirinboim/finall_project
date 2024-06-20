using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Dietitian
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Kind { get; set; }

    public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();

    public virtual ICollection<QueuesForDietitian> QueuesForDietitians { get; set; } = new List<QueuesForDietitian>();

    public virtual ICollection<WorkHour> WorkHours { get; set; } = new List<WorkHour>();
}
