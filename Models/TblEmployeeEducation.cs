using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblEmployeeEducation
    {
        public Guid EmpEduId { get; set; }
        public Guid EmployeeId { get; set; }
        public string Credential { get; set; } = null!;
        public string Field { get; set; } = null!;
        public string Institute { get; set; } = null!;
        public string Fyear { get; set; } = null!;
        public string Tyear { get; set; } = null!;
        public DateTime EffectiveDate { get; set; }
        public string? EducationLev { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }
    }
}
