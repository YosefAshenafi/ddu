using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class EmployeeShift
    {
        public Guid EmployeeShiftId { get; set; }
        public Guid EmployeeId { get; set; }
        public int ShiftId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? Remark { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
        public virtual ShiftHour Shift { get; set; } = null!;
    }
}
