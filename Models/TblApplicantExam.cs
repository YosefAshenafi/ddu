using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblApplicantExam
    {
        public Guid ApplicantExamGuid { get; set; }
        public Guid? AppId { get; set; }
        public bool? IsTheoryTaken { get; set; }
        public bool? IsPracticalTaken { get; set; }
        public bool? IsInterviewTaken { get; set; }
        public int? TheoryPercentage { get; set; }
        public int? PracticalPercentage { get; set; }
        public int? InterviewPercentage { get; set; }
        public double? TheoryExamResult { get; set; }
        public double? PracticalExamResult { get; set; }
        public double? InterviewExamResult { get; set; }
        public double? Result { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual TblApplicant? App { get; set; }
    }
}
