using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDU.Models
{
    public class EmployeeShift
    {
        [Key]
        public Guid EmployeeShiftID { get; set; }

        public Guid EmployeeID { get; set; }

        public int ShiftGroupID { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

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
