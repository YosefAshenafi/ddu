using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvBegBalance
    {
        [Key]
        public int BegID { get; set; }

        public int ItemID { get; set; }

        public double UnitCost { get; set; }

        public double Qty { get; set; }

        public string SessionID { get; set; }

        public string SessionIP { get; set; }

        public string SessionMAC { get; set; }
    }
}
