using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvStore
    {
        [Key]
        public int StoreID { get; set; }

        public string? StoreCode { get; set; }

        public string? StoreLocation { get; set; }

        public int DivID { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }
    }
}
