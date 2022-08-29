using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDU.Models
{
    public class Applicant
    {
        [Key]
        public Guid ApplicantID { get; set; }

        public Guid PositionJobId { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? Phonenumber { get; set; }

        public DateTime? InterviewTime { get; set; } = DateTime.Now;

        public string? Result { get; set; }

        public string? Remark { get; set; }

        public bool PassResult { get; set; }

        public bool Recuited { get; set; }

        public string? Image1Path { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }

        [NotMapped]
        public string? DepartmentName { set; get; }

        [NotMapped]
        public string? PositionName { set; get; }

        [NotMapped]
        public int? NoOfPos { set; get; }

        [NotMapped]
        public DateTime? InterviewDate { set; get; }

        [NotMapped]
        public string? ReportingTo { set; get; }

        [NotMapped]
        public string? RequiredQualification { set; get; }


    }
}
