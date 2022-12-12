using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvCount
    {
        [Key]
        public Guid CountID { get; set; }

        public int DivisionID { get; set; }

        public int CostCenterID { get; set; }

        public int SectionID { get; set; }

        public DateTime CountDate { get; set; }

        public string? StoreKeeper { get; set; }

        public string? CountedBy { get; set; }

        public string? ApprovedBy { get; set; }

        public string? StoreID { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }

    }
}
