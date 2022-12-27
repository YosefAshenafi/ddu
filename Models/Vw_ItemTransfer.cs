using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class Vw_ItemTransfer
    {
        [Key]
        public Guid TransferId { get; set; }

        public string? TransferNumber { get; set; }

        public string? FromStore { get; set; }

        public string? ToStore { get; set; }

        public DateTime? DateCreated { get; set; }

        public string? RequestedBy { get; set; }

        public string? ConfirmBy { get; set; }
    }
}
