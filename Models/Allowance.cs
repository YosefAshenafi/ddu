using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDU.Models
{
    public class Allowance
    {
        [Key]
        public Guid AllowanceID { get; set; }

        public Guid EmployeeID { get; set; }

        public int AllowanceType { get; set; }

        public decimal Amount { get; set; }

        public DateTime? EffectiveDate { get; set; }        
        public string? Remark { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }

        [NotMapped]
        public List<SelectListItem>? ListDepartment { set; get; }

        [NotMapped]
        public string? DepartmentName { set; get; }

        [NotMapped]
        public List<SelectListItem>? ListAllowanceType { set; get; }

        [NotMapped]
        public string? allowanceTypeName { set; get; }

        [NotMapped]
        public string? EmployeeName { set; get; }

    }
}
