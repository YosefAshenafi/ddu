using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class Vw_ReceiveDetail
    {
        public int ItemID { get; set; }

        public string? ItemCode { get; set; }

        public string? ItemName { get; set; }

        public string? Description { get; set; }

        public string? FamilyName { get; set; }

        public string? NatureName { get; set; }

        public string? ItemType { get; set; }

        [Key]
        public Guid ReferenceDetailID { get; set; }

        public Guid ReferenceNo { get; set; }

        public string? UnitMeasure { get; set; }

        public decimal QtyReceived { get; set; }

        public decimal UnitPrice { get; set; }

        public string? Remark { get; set; }

    }
}
