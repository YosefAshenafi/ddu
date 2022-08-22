using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblPosition
    {
        public TblPosition()
        {
            EmployeeTransfers = new HashSet<EmployeeTransfer>();
            TblApplicantInterviewResults = new HashSet<TblApplicantInterviewResult>();
        }

        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        public string? JobTitle { get; set; }
        public string? PositionCode { get; set; }
        public int? Occupation { get; set; }
        public string? OccupationRank { get; set; }
        public double? InitialSalary { get; set; }
        public double? SalaryIncrement { get; set; }
        public double? SalaryCeiling { get; set; }
        public string? EducationLevel { get; set; }
        public string? EducationType { get; set; }
        public string? EducationDescription { get; set; }
        public string? Knowledge { get; set; }
        public string? Skill { get; set; }
        public string? Ability { get; set; }
        public string? Character { get; set; }
        public string? Experiences { get; set; }
        public string? DutiesResponsiblities { get; set; }
        public string? Remark { get; set; }
        public int GradeId { get; set; }
        public bool? IsVacant { get; set; }
        public Guid? PositionTypeGuid { get; set; }
        public bool? EmployementType { get; set; }

        public virtual ICollection<EmployeeTransfer> EmployeeTransfers { get; set; }
        public virtual ICollection<TblApplicantInterviewResult> TblApplicantInterviewResults { get; set; }
    }
}
