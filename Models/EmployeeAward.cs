using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class EmployeeAward
    {
        public Guid EmployeeAwardId { get; set; }
        public Guid EmployeeId { get; set; }
        public byte AwardTypeId { get; set; }
        public string AwardDescription { get; set; } = null!;
        public DateTime AwardedOn { get; set; }
        public Guid AwardedBy { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
    }
}
