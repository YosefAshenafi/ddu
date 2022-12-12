using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvDisposal
    {
        public int DivisionId { get; set; }

        [Key]
        public int DisposalId { get; set; }

        public int CostCenterID { get; set; }

        public int StoreID { get; set; }
        public string? ReferenceNumber { get; set; }

        public string? Description { get; set; }

        public string? RequestedBy { get; set; }

        public string? FinanceDepartment { get; set; }

        public string? GeneralManager { get; set; }

        public DateTime Date { get; set; }

        public int SectionID { get; set; }

        public int Status { get; set; }

        public int StockAccId { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }
    }
}
