using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblLeaveType
    {
        public TblLeaveType()
        {
            TblEmployeeOnLeaves = new HashSet<TblEmployeeOnLeave>();
        }

        public int LeaveTypeId { get; set; }
        public string? LeaveType { get; set; }
        public string? Pay { get; set; }
        public decimal? NoOfDays { get; set; }
        public string? Description { get; set; }
        public string? Condition { get; set; }

        public virtual ICollection<TblEmployeeOnLeave> TblEmployeeOnLeaves { get; set; }
    }
}
