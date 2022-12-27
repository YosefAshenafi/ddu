using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvItemReturn
    {
        [Key]
        public Guid ReturnID { get; set; }

        public int DivisionID { get; set; }

        public int CostCenterID { get; set; }

        public int SectionID { get; set; }

        public DateTime ReturnDate { get; set; }

        public string? StoreID { get; set; }

        public string? ReturnedBy { get; set; } = "";

        public string? ApprovedBy { get; set; } = "";

        public string? ReceivedBy { get; set; } = "";

        public string? Reason { get; set; } = "";

        public string? SessionID { get; set; } = "";

        public string? SessionIP { get; set; } = "";

        public string? SessionMAC { get; set; } = "";
    }
}
