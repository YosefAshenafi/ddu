using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class Vw_GRNList
    {
        [Key]
        public Guid ReferenceNo { get; set; }

        public string? StoreCode { get; set; }

        public string? SupCode { get; set; }

        public string? SupName { get; set; }

        public DateTime? ReceiveDate { get; set; }

        public string? RecivedBy { get; set; }

        public string? ApprovedBy { get; set; }

        public string? GRNNO { get; set; }

        public string? FirstName { get; set; }

        public string? Expr1 { get; set; }

    }
}
