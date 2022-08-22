using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class EvaluationCriterion
    {
        public EvaluationCriterion()
        {
            EmployeeEvaluations = new HashSet<EmployeeEvaluation>();
            EvaluationCriteriaRankMagnitudes = new HashSet<EvaluationCriteriaRankMagnitude>();
        }

        public int EvaluationCriteriaId { get; set; }
        public string EvaluationCriteriaName { get; set; } = null!;
        public int? EvaluationTypeId { get; set; }
        public bool IsForOffice { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual ICollection<EmployeeEvaluation> EmployeeEvaluations { get; set; }
        public virtual ICollection<EvaluationCriteriaRankMagnitude> EvaluationCriteriaRankMagnitudes { get; set; }
    }
}
