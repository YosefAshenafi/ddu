using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class EmployeePerdiemRequest
    {
        public EmployeePerdiemRequest()
        {
            EmployeePerdiems = new HashSet<EmployeePerdiem>();
        }

        public Guid PerDiemRequestGuid { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal NumberofPerdiemDays { get; set; }
        public decimal? NumberOfApprovedDays { get; set; }
        public int? PerDiemType { get; set; }
        public int BudjetYear { get; set; }
        public int IsApproved { get; set; }
        public string? Reason { get; set; }
        public string? ReasonHs { get; set; }
        public string? PerDiemDateRange { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
        public virtual ICollection<EmployeePerdiem> EmployeePerdiems { get; set; }
    }
}
