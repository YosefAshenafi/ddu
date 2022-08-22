using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class EvaluationCriteriaRank
    {
        public EvaluationCriteriaRank()
        {
            EmployeeEvaluations = new HashSet<EmployeeEvaluation>();
        }

        public int EvaluationCriteriaRankId { get; set; }
        public string EvaluationCriteriaRankName { get; set; } = null!;
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual ICollection<EmployeeEvaluation> EmployeeEvaluations { get; set; }
    }
}
