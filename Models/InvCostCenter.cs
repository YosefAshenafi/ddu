using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvCostCenter
    {
        public int DivID { get; set; }

        [Key]
        public int CostID { get; set; }

        public string? CostCode { get; set; }

        public string? CostName { get; set; }

        public int AccId { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }

    }
}
