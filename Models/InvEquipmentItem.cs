using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvEquipmentItem
    {
        public int EqpID { get; set; }

        public int ItemID { get; set; }

        [Key]
        public int EquipmentItemID { get; set; }

        public decimal Quantity { get; set; }

        public string SessionID { get; set; }

        public string SessionIP { get; set; }

        public string SessionMAC { get; set; }
    }
}
