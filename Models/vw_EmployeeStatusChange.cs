using System.ComponentModel.DataAnnotations;
namespace DDU.Models
{
    public class vw_EmployeeStatusChange
    {

        [Key]
        public Guid EmployeeStatusChangeID { get; set; }

        public Guid EmployeeID { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? StatusChange { get; set; }

        public string? Reason { get; set; }
        
        public int TerminationType { get; set; }

        public DateTime? DateOn { get; set; }

        public DateTime? RequestDate { get; set; }

        public string? Remark { get; set; }
        public string? SessionID { get; set; }
        public string? SessionIP { get; set; }
        public string? SessionMAC { get; set; }


    }
}
