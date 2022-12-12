using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvBudget
    {
        public int CostID { get; set; }

        public int SecId { get; set; }

        public int EquipmentID { get; set; }

        public int PeriodNumber { get; set; }

        public DateTime FisicalYear { get; set; }

        public decimal BudAmount { get; set; }

        [Key]
        public int BudId { get; set; }

        public string BudCode { get; set; }

        public decimal CostPerHectoLiter { get; set; }

        public string SessionID { get; set; }

        public string SessionIP { get; set; }

        public string SessionMAC { get; set; }

    }
}
