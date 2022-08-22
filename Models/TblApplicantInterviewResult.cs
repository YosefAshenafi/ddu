using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblApplicantInterviewResult
    {
        public Guid AppExamResuId { get; set; }
        public Guid? ComMemberGuid { get; set; }
        public Guid? AppId { get; set; }
        public double? InterviewResult { get; set; }
        public Guid? AnnouncementGuid { get; set; }
        public int? PositionId { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual TblApplicant? App { get; set; }
        public virtual TblPosition? Position { get; set; }
    }
}
