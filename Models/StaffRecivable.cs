using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class StaffRecivable
    {
        public Guid StaffRecivableId { get; set; }
        public Guid EmployeeId { get; set; }
        public decimal Amount { get; set; }
        public byte ReturnMonth { get; set; }
        public int ReturnYear { get; set; }
        public string Remark { get; set; } = null!;
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
    }
}
