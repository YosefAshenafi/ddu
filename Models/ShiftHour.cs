using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class ShiftHour
    {
        public ShiftHour()
        {
            EmployeeShifts = new HashSet<EmployeeShift>();
        }

        public int ShiftId { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public TimeSpan? BreakStartTime { get; set; }
        public TimeSpan? BreakEndTime { get; set; }
        public int? TimelineType { get; set; }
        public bool? ShiftTime { get; set; }
        public int ShiftGroupId { get; set; }

        public virtual ShiftGroup ShiftGroup { get; set; } = null!;
        public virtual ICollection<EmployeeShift> EmployeeShifts { get; set; }
    }
}
