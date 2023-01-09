using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public partial class InvSection
    {
        public int DivID { get; set; }
        public int CostID { get; set; }
        [Key]
        public int SecId { get; set; }
        public string SecCode { get; set; } = null!;
        public string SecName { get; set; } = null!;
        public string? SessionID { get; set; }
        public string? SessionIP { get; set; }
        public string? SessionMAC { get; set; }
    }
}
