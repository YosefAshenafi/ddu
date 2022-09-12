using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDU.Models;


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
    public DbSet<Department> department { get; set; } = null!;

    public DbSet<PositionJobs> positionJobs { get; set; }

    public DbSet<Positions> positions { get; set; }

    public DbSet<Applicant> applicants { get; set; }

    public DbSet<TblLeaveRequest> tblLeaveRequest { get; set; }

    public DbSet<TblLeaveType> tblLeaveType { get; set; }

    public DbSet<TblEmployeeOnLeave> tblEmployeeOnLeave { get; set; }

    public DbSet<PerDiemCheckAndConfirm> perDiemCheckAndConfirm { get; set; } = null!;

    public DbSet<PerDiemApprove> perDiemApprove { get; set; } = null!;

    public DbSet<PerDiemRequest> PerDiemRequest { get; set; } = null!;

    public DbSet<EmployeeTransfer> employeeTransfer { get; set; } = null!;
}

