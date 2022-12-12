using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvReceive
    {
        [Key]
        public Guid ReferenceNo { get; set; }

        public string? PurchaseOrderNo { get; set; } = "";

        public int StoreID { get; set; } = 1;

        public DateTime ReceiveDate { get; set; } = DateTime.Now;

        public int SupplierID { get; set; } = 1;

        public string? RecivedBy { get; set; }

        public string? ApprovedBy { get; set; }

        public double Exangerate { get; set; } = 1.00;

        public string? Currencytype { get; set; }

        public DateTime PurchasedDate { get; set; }=DateTime.Now;

        public string? GRNNO { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }
    }
}
