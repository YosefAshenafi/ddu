using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class EmployeeEvaluation
    {
        public Guid EmployeeEvaluationId { get; set; }
        public Guid EmployeeEvaluationPeriodId { get; set; }
        public int EvaluationCriteriaId { get; set; }
        public int? EvaluationCriteriaRankId { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeEvaluationPeriod EmployeeEvaluationPeriod { get; set; } = null!;
        public virtual EvaluationCriterion EvaluationCriteria { get; set; } = null!;
        public virtual EvaluationCriteriaRank? EvaluationCriteriaRank { get; set; }
    }
}
