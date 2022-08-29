using System;
using System.Collections.Generic;
﻿using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        public string DepartmentCode { get; set; }

        public string? DepartmentName { get; set; }

        public int? ParentDepartmentID { get; set; }

        public bool? IsActive { get; set; }

        public int? RootDepartmentID { get; set; }

        public int? DisplayDepartmentID { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public int? TotalEmpNo { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }
    }
}
