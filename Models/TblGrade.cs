using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblGrade
    {
        public int GradeId { get; set; }
        public string? GradeName { get; set; }
        public double? MinSalary { get; set; }
        public double? MaxSalary { get; set; }
        public double? MedLimit { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }
    }
}
