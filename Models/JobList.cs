using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class JobList
    {
        [Key]
        public int JobListId { get; set; }

        public string JobTitle { get; set; }

        public string Position { get; set; }

        public int Department { get; set; }

        public int NoOfPos { get; set; }

        public DateTime InterviewDate { get; set; }

        public string ReportingTo { get; set; }

        public string RequiredQualification { get; set; }

        public string SessionID { get; set; }

        public string SessionIP { get; set; }

        public string SessionMAC { get; set; }
    }
}
