using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class Department
    {
        public int DepartmentId { get; set; }
        public string? DepartmentCode { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int? ParentDepartmentId { get; set; }
        public bool? IsActive { get; set; }
        public int? RootDepartmentId { get; set; }
        public int? DisplayDepartmentId { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? TotalEmpNo { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }
    }
}
