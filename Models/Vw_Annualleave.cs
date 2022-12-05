using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class Vw_Annualleave
    {
        [Key]
        public Guid? EmployeeID { get; set; }

        public decimal Balance { get; set; }
        
    }
}
