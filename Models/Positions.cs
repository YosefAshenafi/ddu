using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class Positions
    {
        [Key]
        public int PositionId { get; set; }

        public string Job_title { get; set; }

        public string Position_code { get; set; }

        public int? Occupation { get; set; } = 0;

        public string? Occupation_rank { get; set; } = "";

        public double? Initial_salary { get; set; } = 0.00;

        public double? Salary_increment { get; set; } = 0.00;

        public double Salary_ceiling { get; set; } = 0.00;

        public string? Education_level { get; set; }

        public string? Education_type { get; set; } = "";

        public string? Education_description { get; set; } = "";

        public string? Knowledge { get; set; } = "";

        public string? Skill { get; set; } = "";

        public string? Ability { get; set; } = "";

        public string? Experiences { get; set; } = "";

        public string? Duties_responsiblities { get; set; } = "";

        public string? Remark { get; set; } = "";

        public int? Grade_id { get; set; } = 0;

        public bool? Is_Vacant { get; set; } = false;

        public Guid? PositionTypeGuid { get; set; } = Guid.Empty;

        public bool? EmployementType { get; set; } = false;
    }
}
