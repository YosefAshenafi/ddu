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

        public double QuantityRecived { get; set; }

        public double QuantityTransfer { get; set; }

        public double UnitCost { get; set; }

        public string? Remark { get; set; }
    }
}
