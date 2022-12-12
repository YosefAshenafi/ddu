using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvReceiveDetail
    {
        
        [Key]
        public Guid ReferenceDetailID { get; set; }

        public Guid ReferenceNo { get; set; }

        public int ItemID { get; set; }

        public string? UnitMeasure { get; set; }

        public decimal QtyReceived { get; set; }

        public decimal UnitPrice { get; set; }

        public string? Remark { get; set; }

    }
}
