using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvAdjustment
    {
        [Key]
        public Guid AdjustmentID { get; set; }

        public int DivisionID { get; set; }

        public int CostCenterID { get; set; }

        public int SectionID { get; set; }

        public DateTime AdjustmentDate { get; set; }

        public string? Reason { get; set; }

        public string? StoreID { get; set; }

        public string? AdjustedBY { get; set; }

        public string? ApprovedBy { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }

    }
}
