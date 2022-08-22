using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class EmployeeSkill
    {
        [Key]
        public Guid EmpSkillId { get; set; }

        public Guid EmployeeId { get; set; }

        public int? Aria_valuenow { get; set; }

        public int? Aria_valuemin { get; set; }

        public int? Aria_valuemax { get; set; }

        public string? Skill { get; set; }

        public string? Color { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }

    }
}
