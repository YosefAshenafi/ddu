using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class EmployeeTraining
    {
        public int EmployeeTrainingId { get; set; }
        public string Code { get; set; } = null!;
        public string Topic { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Fdate { get; set; }
        public DateTime Tdate { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }
    }
}
