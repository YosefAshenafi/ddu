using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblApplicantTrainingHistory
    {
        public Guid AppTrainHisId { get; set; }
        public int? SeqNo { get; set; }
        public Guid? AppId { get; set; }
        public string? Institution { get; set; }
        public string? Location { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public string? Duration { get; set; }
        public string? CourseName { get; set; }
        public int? TrainingType { get; set; }
        public double? Expense { get; set; }
        public string? Sponsor { get; set; }
        public string? Remark { get; set; }
        public double? TotalCost { get; set; }
        public int? PercentCovered { get; set; }
        public string? Address { get; set; }
        public string? ContactPerson { get; set; }
        public int? TrainingNature { get; set; }
        public double? OtherCost { get; set; }
        public double? Budget { get; set; }
        public string? PointsScored { get; set; }
        public bool? IsTrainigRelatedWithJob { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual TblApplicant? App { get; set; }
    }
}
