namespace DDU.Models
{
    public class EmployeeTraining
    {
        public int EmployeeTrainingID { get; set; }

        public Guid EmployeeID { get; set; }

        public string? Code { get; set; }

        public string? Topic { get; set; }

        public string? Description { get; set; }

        public DateTime? FDate { get; set; }

        public DateTime? TDate { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }
    }
}
