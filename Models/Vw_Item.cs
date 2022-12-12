using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class Vw_Item
    {
        [Key]
        public int ItemID { get; set; }

        public string ItemCode { get; set; }

        public string ItemName { get; set; }

        public string Description { get; set; }

        public double Quantity { get; set; }

        public decimal ReoredrPoint { get; set; }

        public double Minimum { get; set; }

        public string DivName { get; set; }

        public string FamilyName { get; set; }

        public string NatureName { get; set; }

        public string ItemType { get; set; }     
            
            
            
    }
}
