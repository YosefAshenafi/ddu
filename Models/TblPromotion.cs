using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public partial class TblPromotion
    {
        [Key]
        public Guid EmpPromotionID { get; set; }
        public Guid EmployeeID { get; set; }
        public string? ReferenceNo { get; set; } = null!;
        public DateTime? PDate { get; set; }
        public string? Type { get; set; }
        public string? FDept { get; set; }
        public string? TDept { get; set; }
        public string? FGrade { get; set; }
        public string? TGrade { get; set; }
        public string? FJob { get; set; }
        public string? TJob { get; set; }
        public double? Salary { get; set; }
        public double? NewSalary { get; set; }
        public string? Award { get; set; }
        public string? Remark { get; set; }
        public string? SessionID { get; set; }
        public string? SessionIP { get; set; }
        public string? SessionMAC { get; set; }
        public int? IsDeleted { get; set; }
        public EmployeeRegistration Employee { get; set; }
    }
}
