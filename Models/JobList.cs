using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class JobList
    {
        public int JobListId { get; set; }
        public string? JobTitle { get; set; }
        public string? Position { get; set; }
        public int? Department { get; set; }
        public int? NoOfPos { get; set; }
        public DateTime? InterviewDate { get; set; }
        public string? ReportingTo { get; set; }
        public string? RequiredQualification { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }
    }
}
