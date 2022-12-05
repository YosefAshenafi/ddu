using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public partial class TblDemotion
    {
        [Key]
        public Guid EmpDemoId { get; set; }
        public Guid EmployeeID { get; set; }
        public string? Reference { get; set; } = null!;
        public DateTime? DDate { get; set; }
        public string? FPost { get; set; }
        public string? TPost { get; set; }
        public string? Punishment { get; set; }
        public string? Remark { get; set; }
        public string? SessionID { get; set; }
        public string? SessionIP { get; set; }
        public string? SessionMAC { get; set; }
        public int? IsDeleted { get; set; }
        public EmployeeRegistration Employee { get; set; }
    }
}
