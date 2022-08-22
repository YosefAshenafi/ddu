using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class EvaluationCriteriaRankMagnitude
    {
        public int EvaluationCriteriaRankMagnitudeId { get; set; }
        public int EvaluationCriteriaId { get; set; }
        public int EvaluationCriteriaRankId { get; set; }
        public int Magnitude { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EvaluationCriterion EvaluationCriteria { get; set; } = null!;
    }
}
