

using DDU.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDU.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
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

    public DbSet<PerDiemCheckAndConfirm> perDiemCheckAndConfirm { get; set; } = null!;

    public DbSet<PerDiemApprove> perDiemApprove { get; set; } = null!;

    public DbSet<PerDiemRequest> PerDiemRequest { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}
public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}
