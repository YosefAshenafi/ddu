using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class Vw_ItemReturn
    {
        
        [Key]
        public Guid ReturnID { get; set; }
        public string? StoreCode { get; set; }

        public string? CostCode { get; set; }

        public string? CostName { get; set; }

        public DateTime? ReturnDate { get; set; }

        public string? Reason { get; set; }

        public string? ReceivedBy { get; set; }

        public string? ApprovedBy { get; set; }
    }
}
