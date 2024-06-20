using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class WorkHour
{
    public int Code { get; set; }

    public int DayInTheWeek { get; set; }

    public int DieticanId { get; set; }

    public TimeSpan StartHour { get; set; }

    public TimeSpan EndHour { get; set; }

    public virtual Dietitian Dietican { get; set; }
}
