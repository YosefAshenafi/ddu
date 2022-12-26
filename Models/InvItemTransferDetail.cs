using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvItemTransferDetail
    {
        public DateTime LastUpdated { get; set; }

        [Key]
        public Guid TransferDetailID { get; set; }

        public Guid TransferId { get; set; }

        public int ItemID { get; set; }

        public decimal QuantityRecived { get; set; }

        public decimal QuantityTransfer { get; set; }

        public decimal UnitCost { get; set; }

        public string? Remark { get; set; }
    }
}
