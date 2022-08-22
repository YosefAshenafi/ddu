using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class EmployeePerdiemAdjustment
    {
        public Guid EmpPerdiemAdjId { get; set; }
        public Guid EmpPerdiemId { get; set; }
        public byte PerdiemType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal NetDays { get; set; }
        public double? Amount { get; set; }
        public string? Remark { get; set; }
        public bool? IsBackPay { get; set; }
        public int? PaymentYear { get; set; }
        public int? PaymentMonth { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeePerdiem EmpPerdiem { get; set; } = null!;
    }
}
