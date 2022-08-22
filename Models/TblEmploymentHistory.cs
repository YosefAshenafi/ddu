using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblEmploymentHistory
    {
        public Guid EmpEmploymentId { get; set; }
        public int SeqNo { get; set; }
        public Guid EmployeeId { get; set; }
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
        public string? InstitutionEng { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
    }
}
