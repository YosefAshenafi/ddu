using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblEmployeeFamily
    {
        public Guid EmpFamId { get; set; }
        public Guid EmployeeId { get; set; }
        public string? FamilyName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? RelationType { get; set; }
        public string? Dependancy { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
    }
}
