using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class EmploymentHistory
    {
        [Key]
        public Guid EmpEmploymentId { get; set; }

        public Guid EmployeeId { get; set; }

        public string? Organiazation { get; set; }

        public string? Tax_payment_letter_no { get; set; }

        public string? Job_title { get; set; }

        public DateTime? Date_from { get; set; }

        public DateTime? Date_to { get; set; }

        public double? Salary { get; set; }

        public DateTime? Date_termination { get; set; }

        public string? Termination_reason { get; set; }

        public int? Emp_status { get; set; }

        public string? Net_duration { get; set; }

        public string? Remark { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }
    }
}
