using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class vw_StaffRecivable
    {
        
       [Key]
        public Guid StaffRecivableID { get; set; }

        public int IDNo { get; set; }    

        public Guid EmployeeID { get; set; }

        public decimal Amount { get; set; }

        public int FromMonth { get; set; }

        public int ToMonth { get; set; }

        public int ReturnYear { get; set; }

        public string? Remark { get; set; }

        public string? EmployeeName { set; get; }

        public string? Image1Path { get; set; } = "/images/employee/avatar-1.jpg";

    }
}
