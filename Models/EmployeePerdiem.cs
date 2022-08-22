using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class EmployeePerdiem
    {
        public EmployeePerdiem()
        {
            EmployeePerdiemAdjustments = new HashSet<EmployeePerdiemAdjustment>();
        }

        public Guid EmpPerdiemId { get; set; }
        public int ReferenceNo { get; set; }
        public byte PerdiemType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal NetDays { get; set; }
        public double? Amount { get; set; }
        public string? Remark { get; set; }
        public bool? IsBackPay { get; set; }
        public int? PaymentYear { get; set; }
        public int? PaymentMonth { get; set; }
        public Guid PerDiemRequestGuid { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeePerdiemRequest PerDiemRequestGu { get; set; } = null!;
        public virtual ICollection<EmployeePerdiemAdjustment> EmployeePerdiemAdjustments { get; set; }
    }
}
