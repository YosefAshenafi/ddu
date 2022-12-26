using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class Vw_Adjustment
    {
        [Key]
        public Guid AdjustmentID { get; set; }

        public string? StoreCode { get; set; }

        public DateTime? AdjustmentDate { get; set; }

        public string? Reason { get; set; }

        public string? AdjustedBY { get; set; }

        public string? ApprovedBy { get; set; }
    }
}
