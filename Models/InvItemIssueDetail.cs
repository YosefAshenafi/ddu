using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvItemIssueDetail
    {
        [Key]
        public Guid ItemIssueDetailId { get; set; }

        public Guid ItemIssueID { get; set; }

        public int ItemID { get; set; }

        public string? UnitMeasure { get; set; }

        public decimal Qty { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal UnitPrice { get; set; }

        public string? Remark { get; set; }
    }
}
