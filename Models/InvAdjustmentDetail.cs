using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvAdjustmentDetail
    {
        [Key]
        public Guid AdjustmentDetailId { get; set; }

        public Guid AdjustmentID { get; set; }

        public int ItemID { get; set; }

        public decimal QtyOnHand { get; set; }

        public decimal QtyAdjusted { get; set; }

        public decimal NewQtyOnHand { get; set; }

        public decimal UnitPrice { get; set; }

        public string? Remark { get; set; }
    }
}
