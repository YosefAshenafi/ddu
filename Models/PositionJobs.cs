using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDU.Models
{
    public class PositionJobs
    {
        [Key]
        public Guid PositionJobId { get; set; }

        public int PositionId { get; set; }

        public int DepartmentID { get; set; }

        public int? NoOfPos { get; set; }

        public DateTime? InterviewDate { get; set; }

        public string? RequiredQualification { get; set; }

        public string? ReportingTo { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }

        [NotMapped]
        public List<SelectListItem>? ListPosition { set; get; }

        [NotMapped]
        public List<SelectListItem>? ListDepartment { set; get; }

        [NotMapped]
        public string? DepartmentName { set; get; }

        [NotMapped]
        public string? PositionName { set; get; }

        public static implicit operator PositionJobs(List<PositionJobs> v)
        {
            throw new NotImplementedException();
        }
    }
}
