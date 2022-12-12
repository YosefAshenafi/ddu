using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvItemTransfer
    {

        public int DivisionId { get; set; }

        [Key]
        public Guid TransferId { get; set; }

        public int TransferType { get; set; }

        public string? TransferNumber { get; set; }

        public int Status { get; set; }

        public DateTime DateCreated { get; set; }

        public int TransferToDivId { get; set; }

        public int StoreTo { get; set; }

        public int StoreVia { get; set; }

        public string? Remarks { get; set; }

        public DateTime LastUpdated { get; set; }

        public string? RequestedBy { get; set; }

        public string? ConfirmBy { get; set; }

        public string? DiverName { get; set; }

        public string? PlateNo { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }
    }
}
