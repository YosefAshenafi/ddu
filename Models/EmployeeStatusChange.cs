using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class EmployeeStatusChange
    {
        public Guid EmployeeStatusChangeId { get; set; }
        public Guid EmployeeId { get; set; }
        public byte StatusFromType { get; set; }
        public byte StatusToType { get; set; }
        public DateTime DateOn { get; set; }
        public string Remark { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
    }
}
