using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public partial class InvItemDestination
    {
        [Key]
        public int NatureID { get; set; }
        public string NatureCode { get; set; } = null!;
        public string? NatureName { get; set; }
        public string? SessionID { get; set; }
        public string? SessionIP { get; set; }
        public string? SessionMAC { get; set; }
        public int? IsDeleted { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
