using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class ShiftGroupHistory
    {
        public int ShiftGroupHistoryId { get; set; }
        public Guid EmployeeId { get; set; }
        public int? ShiftGroupId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }
    }
}
