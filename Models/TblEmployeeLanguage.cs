using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblEmployeeLanguage
    {
        public Guid EmpLangId { get; set; }
        public Guid EmployeeId { get; set; }
        public string? Language { get; set; }
        public string? Reading { get; set; }
        public string? Writing { get; set; }
        public string? Speaking { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
    }
}
