using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblPromotion
    {
        public Guid EmpPromotionId { get; set; }
        public Guid EmployeeId { get; set; }
        public string? ReferenceNo { get; set; }
        public DateTime? Pdate { get; set; }
        public string? Type { get; set; }
        public string? Fdept { get; set; }
        public string? Tdept { get; set; }
        public string? Fgrade { get; set; }
        public string? Tgrade { get; set; }
        public string? Fjob { get; set; }
        public string? Tjob { get; set; }
        public double? Salary { get; set; }
        public double? NewSalary { get; set; }
        public string? Award { get; set; }
        public string? Remark { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
    }
}
