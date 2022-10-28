using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class vw_EmployeeTransfer
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

        public string? DepartmentName { set; get; }      
        public string? EmployeeName { set; get; }

        public string? PositionName { set; get; }
    }
}
