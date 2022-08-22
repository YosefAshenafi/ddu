using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblEmployeeTerminate
    {
        public Guid EmpTermId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? TerminateDate { get; set; }
        public int? TerminateType { get; set; }
        public string? TerminateReason { get; set; }
        public string? Remark { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
    }
}
