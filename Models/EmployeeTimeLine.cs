using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class EmployeeTimeLine
    {
        public Guid EmployeeTimeLineId { get; set; }
        public int? TimeLineType { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? NetMinutes { get; set; }
        public int? ShiftId { get; set; }
        public string? Remark { get; set; }
        public string? StrecordId { get; set; }
        public int? PeriodId { get; set; }
        public string? EtrecordId { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
        public virtual Period? Period { get; set; }
    }
}
