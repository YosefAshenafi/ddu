using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class ShiftGroup
    {
        public ShiftGroup()
        {
            ShiftHours = new HashSet<ShiftHour>();
        }

        public int ShiftGroupId { get; set; }
        public string ShiftGroupName { get; set; } = null!;
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual ICollection<ShiftHour> ShiftHours { get; set; }
    }
}
