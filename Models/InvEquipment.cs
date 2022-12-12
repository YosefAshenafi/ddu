using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvEquipment
    {
        public int SectionID { get; set; }

        public int FixID { get; set; }

        [Key]
        public int EquipmentID { get; set; }

        public int SupplierID { get; set; }

        public string EqpCode { get; set; }

        public string EqpName { get; set; }

        public string Capacity { get; set; }

        public string Unit { get; set; }

        public string Mark { get; set; }

        public string ModelNo { get; set; }

        public string SerialNo { get; set; }

        public string ComeFrom { get; set; }

        public int ManufactureYear { get; set; }

        public DateTime DatePurchase { get; set; }

        public string SessionID { get; set; }

        public string SessionIP { get; set; }

        public string SessionMAC { get; set; }

    }
}
