using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class vw_Allowance
    {
        [Key]
        public Guid? EmployeeID { get; set; }

        public int ? IDNo { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public byte? Sex { get; set; }

        public string? Designation { get; set; }

        public DateTime? HireDate { get; set; }

        public decimal PhoneAllowance { get; set; }

        public decimal TransportAllowance { get; set; }

        public decimal FoodAllowance { get; set; }     

        public string? Image1Path { get; set; } = "/images/employee/avatar-1.jpg";


    }
}
