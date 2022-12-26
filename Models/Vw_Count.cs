using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class Vw_Count
    {
        public string? StoreKeeper { get; set; }

        public string? StoreCode { get; set; }

        [Key]
        public Guid CountID { get; set; }

        public DateTime? CountDate { get; set; }

        public string? CountedBy { get; set; }

        public string? ApprovedBy { get; set; }
    }
}
