using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDU.Models
{
    public class StaffRecivable
    {
        [Key]
        public Guid StaffRecivableID { get; set; }

        public Guid EmployeeID { get; set; }

        public decimal Amount { get; set; }

        public int FromMonth { get; set; }

        public int ToMonth { get; set; }

        public int StaffRecivableType { get; set; }

        public int ReturnYear { get; set; }

        public string? Remark { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }

        [NotMapped]
        public List<SelectListItem>? ListStaffRecivableType { set; get; }

        [NotMapped]
        public string? staffRecivableTypeName { set; get; }

        [NotMapped]
        public string? IdNos { set; get; }

        [NotMapped]
        public string? EmployeeName { set; get; }





    }
}
