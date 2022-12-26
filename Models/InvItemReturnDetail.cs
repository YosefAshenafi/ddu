using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvItemReturnDetail
    {
        [Key]
        public Guid ReturnDetailId { get; set; }

        public Guid ReturnID { get; set; }

        public int ItemID { get; set; }

        public decimal QtyReturned { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal UnitPrice { get; set; }

        public string? Remark { get; set; }
    }
}
