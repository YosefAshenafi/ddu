namespace DDU.Models;

    public class ViewModel
    {
        public EmployeeRegistration Registration { get; set; }
        public IEnumerable<EmployeeFamily> EmployeeFamilys { get; set; }
        public IEnumerable<EmployeeEducation> EmployeeEducations { get; set; }
        public IEnumerable<EmploymentHistory> EmploymentHistorys { get; set; }
        public IEnumerable<EmployeeTraining> EmployeeTrainings { get; set; }
        public IEnumerable<EmployeeSkill> EmployeeSkills { get; set; }    
        public EmployeeEducation Education { get; set; }

}
