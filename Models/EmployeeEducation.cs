using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class EmployeeEducation
    {
        [Key]
        public Guid EmpEduId { get; set; }

        public Guid EmployeeID { get; set; }

        public string? Credential { get; set; }

        public string Field { get; set; }

        public string Institute { get; set; }

        public string FYear { get; set; }

        public string TYear { get; set; }

        public DateTime EffectiveDate { get; set; }

        public string? EducationLev { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }
    }
}
