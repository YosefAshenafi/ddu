using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblDemotion
    {
        public Guid EmpDemoId { get; set; }
        public string? Referense { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime? Ddate { get; set; }
        public string? Fpost { get; set; }
        public string? Tpost { get; set; }
        public string? Punishment { get; set; }
        public string? Remark { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
    }
}
