using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblEmployeeOnLeave
    {
        public Guid EmpLeavId { get; set; }
        public string? ReferenceNo { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public double? NoOfDays { get; set; }
        public int? LeaveType { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
        public virtual TblLeaveType? LeaveTypeNavigation { get; set; }
    }
}
