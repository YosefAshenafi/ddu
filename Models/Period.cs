using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class Period
    {
        public Period()
        {
            EmployeeTimeLines = new HashSet<EmployeeTimeLine>();
        }

        public int Id { get; set; }
        public int PeriodNumber { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int FiscalYear { get; set; }
        public bool? CurrentPeriod { get; set; }

        public virtual ICollection<EmployeeTimeLine> EmployeeTimeLines { get; set; }
    }
}
