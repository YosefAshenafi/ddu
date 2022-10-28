using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDU.Models
{
    public class EmployeeStatusChange
    {
        [Key]
        public Guid EmployeeStatusChangeID { get; set; }

        public Guid EmployeeID { get; set; }

        public int StatusType { get; set; }

        public int TerminationType { get; set; }

        public DateTime DateOn { get; set; }

        public DateTime RequestDate { get; set; }

        public string? Remark { get; set; }

        public string? Reason { get; set; }
        

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }

        [NotMapped]
        public List<SelectListItem>? ListStatus { set; get; }

        [NotMapped]
        public string? Status { set; get; }

        [NotMapped]
        public List<SelectListItem>? ListEmployees { set; get; }

        [NotMapped]
        public string? EmployeeName { set; get; }

    }
}
