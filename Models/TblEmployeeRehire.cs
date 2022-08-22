using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblEmployeeRehire
    {
        public Guid EmpRehireId { get; set; }
        public Guid EmployeeId { get; set; }
        public string? ReferenceNo { get; set; }
        public DateTime? RehireDate { get; set; }
        public string? RehireReason { get; set; }
        public string? Remark { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
    }
}
