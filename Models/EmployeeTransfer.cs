using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class EmployeeTransfer
    {
        public Guid TransferId { get; set; }
        public Guid EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string? Remark { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
        public virtual TblPosition Position { get; set; } = null!;
    }
}
