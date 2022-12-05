using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDU.Models
{
    public class EmployeeTransfer
    {
        [Key]
        public Guid TransferID { get; set; }

        public Guid EmployeeID { get; set; }

        public int DepartmentID { get; set; }

        public int PositionId { get; set; }

        public string? TransferType { get; set; }

        public string? LetterNo { get; set; }

        public DateTime? LetterDate { get; set; }

        public DateTime? EffectiveDate { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }

        [NotMapped]
        public List<SelectListItem>? ListEmployees { set; get; }

        [NotMapped]
        public List<SelectListItem>? ListDepartment { set; get; }

        [NotMapped]
        public List<SelectListItem>? ListPosition { set; get; }

        [NotMapped]
        public string? DepartmentName { set; get; }

        [NotMapped]
        public string? EmployeeName { set; get; }

        [NotMapped]
        public string? PositionName { set; get; }
    }
}
