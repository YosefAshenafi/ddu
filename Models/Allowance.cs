using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class Allowance
    {
        public Guid AllowanceId { get; set; }
        public Guid EmployeeId { get; set; }
        public int AllowanceType { get; set; }
        public decimal Amount { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Remark { get; set; } = null!;
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual AllowanceType AllowanceTypeNavigation { get; set; } = null!;
        public virtual EmployeeRegistration Employee { get; set; } = null!;
    }
}
