using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblApplicantEmploymentHistory
    {
        public Guid AppEmploymentId { get; set; }
        public int SeqNo { get; set; }
        public Guid? AppId { get; set; }
        public string? Institution { get; set; }
        public string? Location { get; set; }
        public string? TaxPaymentLetterNo { get; set; }
        public string? JobTitle { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public double? Salary { get; set; }
        public DateTime? DateTermination { get; set; }
        public string? TerminationReason { get; set; }
        public int? EmpStatus { get; set; }
        public string? NetDuration { get; set; }
        public string? Remark { get; set; }
        public string? FieldofStudy { get; set; }
        public string? EducationLevel { get; set; }

        public virtual TblApplicant? App { get; set; }
    }
}
