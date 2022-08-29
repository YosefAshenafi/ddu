namespace DDU.Models
{
    public class PositionViewModel
    {
        public IEnumerable<Positions>? Positions { get; set; }
        public IEnumerable<Department>? Department { get; set; }
        public IEnumerable<Applicant>? Applicants { get; set; }

    }
}
