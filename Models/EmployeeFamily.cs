using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class EmployeeFamily
    {
        [Key]
        public Guid EmpFamId { get; set; }

        public Guid EmployeeId { get; set; }

        public string FamilyName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string RelationType { get; set; }

        public string? Dependancy { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }
    }
}
