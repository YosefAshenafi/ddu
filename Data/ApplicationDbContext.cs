
using DDU.Models;
using Microsoft.EntityFrameworkCore;

namespace DDU.Data;

   
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    public DbSet<EmployeeRegistration> employeeRegistration { get; set; }

    public DbSet<EmployeeEducation> employeeEducation { get; set; }

    public DbSet<EmployeeFamily> employeeFamily { get; set; }

    public DbSet<EmploymentHistory> employmentHistory { get; set; }

    public DbSet<EmployeeTraining> employeeTraining { get; set; }    

    public DbSet<JobList> jobList { get; set; }

    public DbSet<EmployeeSkill> employeeSkill { get; set; }
    public DbSet<Department> department { get; set; }


}
