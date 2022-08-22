using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class AllowanceType
    {
        public AllowanceType()
        {
            Allowances = new HashSet<Allowance>();
        }

        public int AllowanceTypeId { get; set; }
        public string AllowanceTypeName { get; set; } = null!;
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual ICollection<Allowance> Allowances { get; set; }
    }
}
