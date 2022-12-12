using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvDisposalDetail
    {
        [Key]
        public int ID { get; set; }

        public int DisposedId { get; set; }

        public int ItemID { get; set; }

        public double QuantityDisposed { get; set; }

        public double UnitCost { get; set; }

        public decimal QuantityInHand { get; set; }

        public string? Remark { get; set; }
    }
}
