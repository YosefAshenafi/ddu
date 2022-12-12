using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvSupplier
    {
        [Key]
        public int SupplierID { get; set; }

        public string? SupCode { get; set; }

        public string? SupName { get; set; }

        public string? Catagory { get; set; }

        public int AccountId { get; set; }

        public string? Address { get; set; }

        public string? WebAddress { get; set; }

        public string? Pobox { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public string? Contact1 { get; set; }

        public string? Telephone1 { get; set; }

        public string? Mobile1 { get; set; }

        public string? Fax1 { get; set; }

        public string? Email1 { get; set; }

        public string? Contact2 { get; set; }

        public string? Telephone2 { get; set; }

        public string? Mobile2 { get; set; }

        public string? Fax2 { get; set; }

        public string? Email2 { get; set; }

        public string? Contact3 { get; set; }

        public string? Telephone3 { get; set; }

        public string? Mobile3 { get; set; }

        public string? Fax3 { get; set; }

        public string? Email3 { get; set; }

        public string? Remarks { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }

    }
}
