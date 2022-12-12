using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvItemIssue
    {
        [Key]
        public Guid ItemIssueID { get; set; }

        public int StoreID { get; set; }

        public int DivisionID { get; set; }

        public int CostCenterID { get; set; }

        public int SectionID { get; set; }

        public int NatureID { get; set; }

        public string? PhaseNo { get; set; } = "";

        public int EquipmentID { get; set; } = 1;

        public int IssueAccountID { get; set; }= 1;

        public string? Status { get; set; } = "";

        public DateTime IssueDate { get; set; }

        public string? IssueNumber { get; set; }

        public int IntegerPart { get; set; }

        public string? Title { get; set; } = "";

        public string? PreparedBy { get; set; }

        public string? ApprovedBy { get; set; }

        public DateTime LastModified { get; set; } = DateTime.Now;

        public string? ExtensionNumber { get; set; } = "";

        public string? ItemNumber { get; set; } = "";

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }
    }
}
