using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class Vw_ItemIssue
    {
        [Key]
        public Guid ItemIssueID { get; set; }

        public string? StoreCode { get; set; }

        public string? CostCode { get; set; }

        public string? CostName { get; set; }

        public string? IssueNumber { get; set; }

        public DateTime IssueDate { get; set; }

        public string? PreparedBy { get; set; }

        public string? ApprovedBy { get; set; }
    }
}
