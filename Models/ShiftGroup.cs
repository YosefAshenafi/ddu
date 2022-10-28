using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class ShiftGroup
    {
        [Key]
        public int ShiftGroupID { get; set; }

        public string? ShiftGroupName { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }

    }
}
