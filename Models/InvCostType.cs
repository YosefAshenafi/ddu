using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvCostType
    {
        [Key]
        public int CostTypeId { get; set; }

        public string CostTypeCode { get; set; }

        public string CostTypeName { get; set; }

        public string SessionID { get; set; }

        public string SessionIP { get; set; }

        public string SessionMAC { get; set; }

    }
}
