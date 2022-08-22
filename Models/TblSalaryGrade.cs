using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblSalaryGrade
    {
        public string GradeId { get; set; } = null!;
        public string? Description { get; set; }
        public double? MinSalary { get; set; }
        public double? MaxSalary { get; set; }
        public string? LeaveType { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }
    }
}
