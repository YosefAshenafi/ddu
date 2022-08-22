using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class EmployeePunishment
    {
        public Guid EmployeePunId { get; set; }
        public int ReferenceNo { get; set; }
        public Guid EmployeeId { get; set; }
        public byte PunType { get; set; }
        public byte? PunishmentDegree { get; set; }
        public byte? PunishmentReason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal NetDays { get; set; }
        public string? Remark { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
    }
}
