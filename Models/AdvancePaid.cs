using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class AdvancePaid
    {
        public Guid AdvancePaidId { get; set; }
        public Guid EmployeeId { get; set; }
        public int Year { get; set; }
        public byte Month { get; set; }
        public decimal Amount { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
    }
}
