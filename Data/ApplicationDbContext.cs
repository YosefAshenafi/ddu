using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDU.Models;


namespace DDU.Data;

   
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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

    public DbSet<TblPromotion> tblPromotion { get; set; }
    public DbSet<TblDemotion> tblDemotion { get; set; }

    public DbSet<vw_EmployeeTransfer> vw_EmployeeTransfer { get; set; } = null!;

    public DbSet<SalaryChange> salaryChange { get; set; } = null!;

    public DbSet<AspNetRoles> aspNetRoles { get; set; } = null!;

    public DbSet<vw_EmployeeStatusChange> vw_EmployeeStatusChange { get; set; } = null!;

    public DbSet<tblLookup> tblLookup { get; set; } = null!;

    public DbSet<EmployeeStatusChange> employeeStatusChange { get; set; } = null!;

    public DbSet<Payroll> payroll { get; set; } = null!;

    public DbSet<Allowance> allowance { get; set; } = null!;

    public DbSet<AllowanceType> allowanceType { get; set; } = null!;

    public DbSet<vw_Allowance> vw_Allowance { get; set; } = null!;   

    public DbSet<StaffRecivable> staffRecivable { get; set; } = null!;

    public DbSet<EmployeeShift> employeeShift { get; set; } = null!;

    public  DbSet<EmployeeRecivable> employeeRecivable { get; set; } = null!;

    //public DbSet<StaffRecivable> staffRecivable { get; set; } = null!;

    public DbSet<vw_StaffRecivable> vw_StaffRecivable { get; set; } = null!;

    public DbSet<Attendance> Attendance { get; set; }

    public DbSet<Vw_Annualleave> vw_Annualleave { get; set; } = null!;

    public DbSet<DailyLabourer> dailyLabourer { get; set; } = null!;

    public DbSet<InvInventoryItem> invInventoryItem { get; set; } = null!;

    public DbSet<InvReceive> invReceive { get; set; } = null!;

    public DbSet<InvReceiveDetail> invReceiveDetail { get; set; } = null!;

    public DbSet<Vw_Item> vw_Item { get; set; } = null!;

    public DbSet<InvStore> invStore { get; set; } = null!;

    public DbSet<InvSupplier> invSupplier { get; set; } = null!;

    public DbSet<InvItemIssue> invItemIssue { get; set; } = null!;

    public DbSet<InvItemIssueDetail> invItemIssueDetail { get; set; } = null!;

    public DbSet<InvCostCenter> invCostCenter { get; set; } = null!;

    public DbSet<InvItemReturn> invItemReturn { get; set; } = null!;

    public DbSet<InvItemReturnDetail> invItemReturnDetail { get; set; } = null!;

    public DbSet<InvDisposal> invDisposal { get; set; } = null!;

    public DbSet<InvDisposalDetail> invDisposalDetail { get; set; } = null!;

    public DbSet<InvCount> invCount { get; set; } = null!;

    public DbSet<InvCountDetail> invCountDetail { get; set; } = null!;

    public DbSet<InvAdjustment> invAdjustment { get; set; } = null!;

    public DbSet<InvAdjustmentDetail> invAdjustmentDetail { get; set; } = null!;

    public DbSet<InvItemTransferDetail> invItemTransferDetail { get; set; } = null!;

    public DbSet<InvItemTransfer> invItemTransfer { get; set; } = null!;   


    public string strConnectionString = "User Id=sa;Password=Ahmi#comp#1;Server=.;Database=DDUDB;";  

    //public string strConnectionString = "User Id=db_a676b9_ddu_admin;Password=P@ssw0rd;Server=sql5097.site4now.net;Database=db_a676b9_ddu;";
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

