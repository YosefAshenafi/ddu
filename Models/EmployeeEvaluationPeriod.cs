using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class EmployeeEvaluationPeriod
    {
        public EmployeeEvaluationPeriod()
        {
            EmployeeEvaluations = new HashSet<EmployeeEvaluation>();
        }

        public Guid EmployeeEvaluationPeriodId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime EvaluationPeriodStartDate { get; set; }
        public DateTime EvaluationPeriodEndDate { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual EmployeeRegistration Employee { get; set; } = null!;
        public virtual ICollection<EmployeeEvaluation> EmployeeEvaluations { get; set; }
    }
}
