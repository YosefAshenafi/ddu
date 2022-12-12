using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvCountDetail
    {
        [Key]
        public Guid CountDetailId { get; set; }

        public Guid CountID { get; set; }

        public int ItemID { get; set; }

        public decimal QtyOnHand { get; set; }

        public decimal PhysicalCount { get; set; }

        public decimal Difference { get; set; }

        public decimal UnitPrice { get; set; }

        public string? Remark { get; set; }

    }
}
