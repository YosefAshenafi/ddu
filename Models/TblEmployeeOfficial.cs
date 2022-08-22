using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblEmployeeOfficial
    {
        public Guid EmpOffId { get; set; }
        public Guid EmployeeId { get; set; }
        public string? Department { get; set; }
        public string? Grade { get; set; }
        public string? JobTitle { get; set; }
        public string? State { get; set; }
        public string? EmployementType { get; set; }
        public DateTime? DateOfHire { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public string? HiringReason { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
    }
}
