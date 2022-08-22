using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblEducationHistory
    {
        public Guid EmpEduHisId { get; set; }
        public int SeqNo { get; set; }
        public Guid EmployeeId { get; set; }
        public string? Institution { get; set; }
        public string? Location { get; set; }
        public int? EducationType { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public string? NetDuration { get; set; }
        public string? FieldOfStudy { get; set; }
        public string? CertificateObtained { get; set; }
        public double? Gpa { get; set; }
        public string? Remark { get; set; }
        public int? Country { get; set; }
        public bool? Attachment { get; set; }
        public string? NotAttachedReson { get; set; }
        public bool? IsEducationRelatedWithJob { get; set; }
        public bool? GivenByTheOrg { get; set; }
        public string? FullAddress { get; set; }
        public string? Sponsor { get; set; }
        public bool? IsonJob { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
    }
}
