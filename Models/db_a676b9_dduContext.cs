using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DDU.Models
{
    public partial class db_a676b9_dduContext : DbContext
    {
        public db_a676b9_dduContext()
        {
        }

        public db_a676b9_dduContext(DbContextOptions<db_a676b9_dduContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdvancePaid> AdvancePaids { get; set; } = null!;
        public virtual DbSet<Allowance> Allowances { get; set; } = null!;
        public virtual DbSet<AllowanceType> AllowanceTypes { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<EmployeeAward> EmployeeAwards { get; set; } = null!;
        public virtual DbSet<EmployeeDeduction> EmployeeDeductions { get; set; } = null!;
        public virtual DbSet<EmployeeEvaluation> EmployeeEvaluations { get; set; } = null!;
        public virtual DbSet<EmployeeEvaluationPeriod> EmployeeEvaluationPeriods { get; set; } = null!;
        public virtual DbSet<EmployeePerdiem> EmployeePerdiems { get; set; } = null!;
        public virtual DbSet<EmployeePerdiemAdjustment> EmployeePerdiemAdjustments { get; set; } = null!;
        public virtual DbSet<EmployeePerdiemRequest> EmployeePerdiemRequests { get; set; } = null!;
        public virtual DbSet<EmployeePunishment> EmployeePunishments { get; set; } = null!;
        public virtual DbSet<EmployeeRegistration> EmployeeRegistrations { get; set; } = null!;
        public virtual DbSet<EmployeeShift> EmployeeShifts { get; set; } = null!;
        public virtual DbSet<EmployeeStatusChange> EmployeeStatusChanges { get; set; } = null!;
        public virtual DbSet<EmployeeTimeLine> EmployeeTimeLines { get; set; } = null!;
        public virtual DbSet<EmployeeTraining> EmployeeTrainings { get; set; } = null!;
        public virtual DbSet<EmployeeTransfer> EmployeeTransfers { get; set; } = null!;
        public virtual DbSet<EvaluationCriteriaRank> EvaluationCriteriaRanks { get; set; } = null!;
        public virtual DbSet<EvaluationCriteriaRankMagnitude> EvaluationCriteriaRankMagnitudes { get; set; } = null!;
        public virtual DbSet<EvaluationCriterion> EvaluationCriteria { get; set; } = null!;
        public virtual DbSet<JobList> JobLists { get; set; } = null!;
        public virtual DbSet<Organization> Organizations { get; set; } = null!;
        public virtual DbSet<Period> Periods { get; set; } = null!;
        public virtual DbSet<ShiftGroup> ShiftGroups { get; set; } = null!;
        public virtual DbSet<ShiftGroupHistory> ShiftGroupHistories { get; set; } = null!;
        public virtual DbSet<ShiftHour> ShiftHours { get; set; } = null!;
        public virtual DbSet<StaffRecivable> StaffRecivables { get; set; } = null!;
        public virtual DbSet<TblApplicant> TblApplicants { get; set; } = null!;
        public virtual DbSet<TblApplicantEducationHistory> TblApplicantEducationHistories { get; set; } = null!;
        public virtual DbSet<TblApplicantEmploymentHistory> TblApplicantEmploymentHistories { get; set; } = null!;
        public virtual DbSet<TblApplicantExam> TblApplicantExams { get; set; } = null!;
        public virtual DbSet<TblApplicantInterviewResult> TblApplicantInterviewResults { get; set; } = null!;
        public virtual DbSet<TblApplicantTrainingHistory> TblApplicantTrainingHistories { get; set; } = null!;
        public virtual DbSet<TblDemotion> TblDemotions { get; set; } = null!;
        public virtual DbSet<TblEducationHistory> TblEducationHistories { get; set; } = null!;
        public virtual DbSet<TblEmployeeAddress> TblEmployeeAddresses { get; set; } = null!;
        public virtual DbSet<TblEmployeeEducation> TblEmployeeEducations { get; set; } = null!;
        public virtual DbSet<TblEmployeeFamily> TblEmployeeFamilies { get; set; } = null!;
        public virtual DbSet<TblEmployeeLanguage> TblEmployeeLanguages { get; set; } = null!;
        public virtual DbSet<TblEmployeeOfficial> TblEmployeeOfficials { get; set; } = null!;
        public virtual DbSet<TblEmployeeOnLeave> TblEmployeeOnLeaves { get; set; } = null!;
        public virtual DbSet<TblEmployeeRehire> TblEmployeeRehires { get; set; } = null!;
        public virtual DbSet<TblEmployeeTerminate> TblEmployeeTerminates { get; set; } = null!;
        public virtual DbSet<TblEmploymentHistory> TblEmploymentHistories { get; set; } = null!;
        public virtual DbSet<TblGrade> TblGrades { get; set; } = null!;
        public virtual DbSet<TblLeaveRequest> TblLeaveRequests { get; set; } = null!;
        public virtual DbSet<TblLeaveType> TblLeaveTypes { get; set; } = null!;
        public virtual DbSet<TblPosition> TblPositions { get; set; } = null!;
        public virtual DbSet<TblPromotion> TblPromotions { get; set; } = null!;
        public virtual DbSet<TblSalaryGrade> TblSalaryGrades { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=sql5097.site4now.net;Database=db_a676b9_ddu;user id=db_a676b9_ddu_admin; password=P@ssw0rd;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdvancePaid>(entity =>
            {
                entity.ToTable("AdvancePaid");

                entity.Property(e => e.AdvancePaidId)
                    .HasColumnName("AdvancePaidID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AdvancePaids)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdvancePaid_EmployeeRegistration");
            });

            modelBuilder.Entity<Allowance>(entity =>
            {
                entity.ToTable("Allowance");

                entity.Property(e => e.AllowanceId)
                    .HasColumnName("AllowanceID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");

                entity.HasOne(d => d.AllowanceTypeNavigation)
                    .WithMany(p => p.Allowances)
                    .HasForeignKey(d => d.AllowanceType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Allowance_Allowance");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Allowances)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Allowance_EmployeeRegistration");
            });

            modelBuilder.Entity<AllowanceType>(entity =>
            {
                entity.ToTable("AllowanceType");

                entity.Property(e => e.AllowanceTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("AllowanceTypeID");

                entity.Property(e => e.AllowanceTypeName).HasMaxLength(50);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentCode).HasMaxLength(50);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.DisplayDepartmentId).HasColumnName("DisplayDepartmentID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ParentDepartmentId).HasColumnName("ParentDepartmentID");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.RootDepartmentId).HasColumnName("RootDepartmentID");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");
            });

            modelBuilder.Entity<EmployeeAward>(entity =>
            {
                entity.ToTable("EmployeeAward");

                entity.Property(e => e.EmployeeAwardId)
                    .HasColumnName("EmployeeAwardID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AwardTypeId).HasColumnName("AwardTypeID");

                entity.Property(e => e.AwardedOn).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeAwards)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeAward_EmployeeRegistration");
            });

            modelBuilder.Entity<EmployeeDeduction>(entity =>
            {
                entity.HasKey(e => e.EmployeeDeduId);

                entity.ToTable("Employee_Deduction");

                entity.Property(e => e.EmployeeDeduId)
                    .HasColumnName("EmployeeDeduID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Remark).HasMaxLength(250);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeDeductions)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Deduction_EmployeeRegistration");
            });

            modelBuilder.Entity<EmployeeEvaluation>(entity =>
            {
                entity.ToTable("EmployeeEvaluation");

                entity.Property(e => e.EmployeeEvaluationId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeEvaluationID");

                entity.Property(e => e.EmployeeEvaluationPeriodId).HasColumnName("EmployeeEvaluationPeriodID");

                entity.Property(e => e.EvaluationCriteriaId).HasColumnName("EvaluationCriteriaID");

                entity.Property(e => e.EvaluationCriteriaRankId).HasColumnName("EvaluationCriteriaRankID");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");

                entity.HasOne(d => d.EmployeeEvaluationPeriod)
                    .WithMany(p => p.EmployeeEvaluations)
                    .HasForeignKey(d => d.EmployeeEvaluationPeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeEvaluation_EmployeeEvaluationPeriod");

                entity.HasOne(d => d.EvaluationCriteria)
                    .WithMany(p => p.EmployeeEvaluations)
                    .HasForeignKey(d => d.EvaluationCriteriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeEvaluation_EvaluationCriteria");

                entity.HasOne(d => d.EvaluationCriteriaRank)
                    .WithMany(p => p.EmployeeEvaluations)
                    .HasForeignKey(d => d.EvaluationCriteriaRankId)
                    .HasConstraintName("FK_EmployeeEvaluation_EvaluationCriteriaRank");
            });

            modelBuilder.Entity<EmployeeEvaluationPeriod>(entity =>
            {
                entity.ToTable("EmployeeEvaluationPeriod");

                entity.Property(e => e.EmployeeEvaluationPeriodId)
                    .HasColumnName("EmployeeEvaluationPeriodID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EvaluationPeriodEndDate).HasColumnType("date");

                entity.Property(e => e.EvaluationPeriodStartDate).HasColumnType("date");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeEvaluationPeriods)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeEvaluationPeriod_EmployeeRegistration");
            });

            modelBuilder.Entity<EmployeePerdiem>(entity =>
            {
                entity.HasKey(e => e.EmpPerdiemId);

                entity.ToTable("EmployeePerdiem");

                entity.Property(e => e.EmpPerdiemId)
                    .HasColumnName("EmpPerdiemID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.NetDays).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Remark)
                    .HasMaxLength(250)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID")
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP")
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC")
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.PerDiemRequestGu)
                    .WithMany(p => p.EmployeePerdiems)
                    .HasForeignKey(d => d.PerDiemRequestGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeePerdiem_EmployeePerdiemRequest");
            });

            modelBuilder.Entity<EmployeePerdiemAdjustment>(entity =>
            {
                entity.HasKey(e => e.EmpPerdiemAdjId);

                entity.ToTable("EmployeePerdiemAdjustment");

                entity.Property(e => e.EmpPerdiemAdjId)
                    .HasColumnName("EmpPerdiemAdjID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.EmpPerdiemId).HasColumnName("EmpPerdiemID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.NetDays).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Remark)
                    .HasMaxLength(250)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID")
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP")
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC")
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.EmpPerdiem)
                    .WithMany(p => p.EmployeePerdiemAdjustments)
                    .HasForeignKey(d => d.EmpPerdiemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeePerdiemAdjustment_EmployeePerdiem");
            });

            modelBuilder.Entity<EmployeePerdiemRequest>(entity =>
            {
                entity.HasKey(e => e.PerDiemRequestGuid);

                entity.ToTable("EmployeePerdiemRequest");

                entity.Property(e => e.PerDiemRequestGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateFrom).HasColumnType("smalldatetime");

                entity.Property(e => e.DateTo).HasColumnType("smalldatetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.NumberOfApprovedDays).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NumberofPerdiemDays).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PerDiemDateRange).HasMaxLength(50);

                entity.Property(e => e.Reason).HasMaxLength(150);

                entity.Property(e => e.ReasonHs)
                    .HasMaxLength(150)
                    .HasColumnName("ReasonHS");

                entity.Property(e => e.RequestDate).HasColumnType("smalldatetime");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID")
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP")
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC")
                    .UseCollation("Latin1_General_CI_AS");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeePerdiemRequests)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeePerdiemRequest_EmployeeRegistration");
            });

            modelBuilder.Entity<EmployeePunishment>(entity =>
            {
                entity.HasKey(e => e.EmployeePunId)
                    .HasName("PK_EmployeePPL");

                entity.ToTable("EmployeePunishment");

                entity.Property(e => e.EmployeePunId)
                    .HasColumnName("EmployeePunID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.NetDays).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ReferenceNo).ValueGeneratedOnAdd();

                entity.Property(e => e.Remark).HasMaxLength(250);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeePunishments)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeePunishment_EmployeeRegistration");
            });

            modelBuilder.Entity<EmployeeRegistration>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK_Employee");

                entity.ToTable("EmployeeRegistration");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Extension).HasMaxLength(5);

                entity.Property(e => e.FirstName).HasMaxLength(25);

                entity.Property(e => e.HouseNo).HasMaxLength(15);

                entity.Property(e => e.Idno)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDNo");

                entity.Property(e => e.Kebele).HasMaxLength(15);

                entity.Property(e => e.LastName).HasMaxLength(25);

                entity.Property(e => e.MiddleName).HasMaxLength(25);

                entity.Property(e => e.NationalIdno)
                    .HasMaxLength(50)
                    .HasColumnName("NationalIDNo");

                entity.Property(e => e.PensionAgencyId)
                    .HasMaxLength(50)
                    .HasColumnName("PensionAgencyID");

                entity.Property(e => e.PensionApplicationDate).HasColumnType("date");

                entity.Property(e => e.PensionIdrecievedDate)
                    .HasColumnType("date")
                    .HasColumnName("PensionIDRecievedDate");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.ShiftGroupId).HasColumnName("ShiftGroupID");

                entity.Property(e => e.SubCityOrTownId).HasColumnName("SubCityOrTownID");

                entity.Property(e => e.Telephone).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<EmployeeShift>(entity =>
            {
                entity.ToTable("EmployeeShift");

                entity.Property(e => e.EmployeeShiftId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeShiftID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeShifts)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeShift_EmployeeRegistration");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EmployeeShifts)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeShift_Shift_Hours");
            });

            modelBuilder.Entity<EmployeeStatusChange>(entity =>
            {
                entity.ToTable("EmployeeStatusChange");

                entity.Property(e => e.EmployeeStatusChangeId)
                    .HasColumnName("EmployeeStatusChangeID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateOn).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeStatusChanges)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeStatusChange_EmployeeRegistration");
            });

            modelBuilder.Entity<EmployeeTimeLine>(entity =>
            {
                entity.ToTable("EmployeeTimeLine");

                entity.Property(e => e.EmployeeTimeLineId)
                    .HasColumnName("EmployeeTimeLineID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.EtrecordId)
                    .HasMaxLength(50)
                    .HasColumnName("ETRecordID");

                entity.Property(e => e.PeriodId).HasColumnName("periodId");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.StrecordId)
                    .HasMaxLength(50)
                    .HasColumnName("STRecordID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeTimeLines)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeTimeLine_EmployeeRegistration");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.EmployeeTimeLines)
                    .HasForeignKey(d => d.PeriodId)
                    .HasConstraintName("FK_EmployeeTimeLine_Period");
            });

            modelBuilder.Entity<EmployeeTraining>(entity =>
            {
                entity.ToTable("EmployeeTraining");

                entity.Property(e => e.EmployeeTrainingId).HasColumnName("EmployeeTrainingID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Fdate)
                    .HasColumnType("date")
                    .HasColumnName("FDate");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.Tdate)
                    .HasColumnType("date")
                    .HasColumnName("TDate");

                entity.Property(e => e.Topic).HasMaxLength(200);
            });

            modelBuilder.Entity<EmployeeTransfer>(entity =>
            {
                entity.HasKey(e => e.TransferId);

                entity.ToTable("Employee_Transfer");

                entity.Property(e => e.TransferId)
                    .HasColumnName("TransferID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeTransfers)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Transfer_EmployeeRegistration");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.EmployeeTransfers)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Transfer_tblPosition");
            });

            modelBuilder.Entity<EvaluationCriteriaRank>(entity =>
            {
                entity.ToTable("EvaluationCriteriaRank");

                entity.Property(e => e.EvaluationCriteriaRankId).HasColumnName("EvaluationCriteriaRankID");

                entity.Property(e => e.EvaluationCriteriaRankName).HasMaxLength(50);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");
            });

            modelBuilder.Entity<EvaluationCriteriaRankMagnitude>(entity =>
            {
                entity.ToTable("EvaluationCriteriaRankMagnitude");

                entity.Property(e => e.EvaluationCriteriaRankMagnitudeId).HasColumnName("EvaluationCriteriaRankMagnitudeID");

                entity.Property(e => e.EvaluationCriteriaId).HasColumnName("EvaluationCriteriaID");

                entity.Property(e => e.EvaluationCriteriaRankId).HasColumnName("EvaluationCriteriaRankID");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");

                entity.HasOne(d => d.EvaluationCriteria)
                    .WithMany(p => p.EvaluationCriteriaRankMagnitudes)
                    .HasForeignKey(d => d.EvaluationCriteriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EvaluationCriteriaRankMagnitude_EvaluationCriteria");
            });

            modelBuilder.Entity<EvaluationCriterion>(entity =>
            {
                entity.HasKey(e => e.EvaluationCriteriaId);

                entity.Property(e => e.EvaluationCriteriaId).HasColumnName("EvaluationCriteriaID");

                entity.Property(e => e.EvaluationTypeId).HasColumnName("EvaluationTypeID");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");
            });

            modelBuilder.Entity<JobList>(entity =>
            {
                entity.ToTable("JobList");

                entity.Property(e => e.InterviewDate).HasColumnType("datetime");

                entity.Property(e => e.JobTitle).HasMaxLength(50);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.ReportingTo).HasMaxLength(50);

                entity.Property(e => e.RequiredQualification).HasMaxLength(50);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.OrgGuid);

                entity.ToTable("Organization");

                entity.Property(e => e.OrgGuid).ValueGeneratedNever();

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.DescriptionAm).HasMaxLength(200);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMail");

                entity.Property(e => e.Logo).HasColumnType("image");

                entity.Property(e => e.OrgProclamationNo).HasMaxLength(50);

                entity.Property(e => e.OrgType).HasMaxLength(10);

                entity.Property(e => e.ParentAdministrationCode).HasMaxLength(10);

                entity.Property(e => e.Pobox)
                    .HasMaxLength(50)
                    .HasColumnName("POBox");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.Telephone).HasMaxLength(50);

                entity.Property(e => e.WebUrl)
                    .HasMaxLength(50)
                    .HasColumnName("WebURL");

                entity.Property(e => e.WeredaCode).HasMaxLength(10);

                entity.Property(e => e.ZoneCode).HasMaxLength(10);
            });

            modelBuilder.Entity<Period>(entity =>
            {
                entity.ToTable("Period");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.From).HasColumnType("datetime");

                entity.Property(e => e.To).HasColumnType("datetime");
            });

            modelBuilder.Entity<ShiftGroup>(entity =>
            {
                entity.ToTable("ShiftGroup");

                entity.Property(e => e.ShiftGroupId).HasColumnName("ShiftGroupID");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.ShiftGroupName).HasMaxLength(50);
            });

            modelBuilder.Entity<ShiftGroupHistory>(entity =>
            {
                entity.ToTable("ShiftGroupHistory");

                entity.Property(e => e.ShiftGroupHistoryId).HasColumnName("ShiftGroupHistoryID");

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.ShiftGroupId).HasColumnName("ShiftGroupID");
            });

            modelBuilder.Entity<ShiftHour>(entity =>
            {
                entity.HasKey(e => e.ShiftId);

                entity.ToTable("Shift_Hours");

                entity.Property(e => e.ShiftId)
                    .ValueGeneratedNever()
                    .HasColumnName("ShiftID");

                entity.Property(e => e.ShiftGroupId).HasColumnName("ShiftGroupID");

                entity.HasOne(d => d.ShiftGroup)
                    .WithMany(p => p.ShiftHours)
                    .HasForeignKey(d => d.ShiftGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shift_Hours_ShiftGroup");
            });

            modelBuilder.Entity<StaffRecivable>(entity =>
            {
                entity.ToTable("StaffRecivable");

                entity.Property(e => e.StaffRecivableId)
                    .ValueGeneratedNever()
                    .HasColumnName("StaffRecivableID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.StaffRecivables)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffRecivable_EmployeeRegistration");
            });

            modelBuilder.Entity<TblApplicant>(entity =>
            {
                entity.HasKey(e => e.AppId);

                entity.ToTable("tblApplicant");

                entity.Property(e => e.AppId).ValueGeneratedNever();

                entity.Property(e => e.Allowance).HasColumnName("allowance");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("birth_date");

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(50)
                    .HasColumnName("birth_place");

                entity.Property(e => e.CardFee).HasColumnName("card_fee");

                entity.Property(e => e.CostSharingMonthlyPayment).HasColumnName("cost_sharing_monthly_payment");

                entity.Property(e => e.CostSharingTotalAmount).HasColumnName("cost_sharing_total_amount");

                entity.Property(e => e.CostSharingTotalPaid).HasColumnName("cost_sharing_total_paid");

                entity.Property(e => e.EducationDescription)
                    .HasMaxLength(50)
                    .HasColumnName("education_description");

                entity.Property(e => e.EducationLevel).HasColumnName("education_level");

                entity.Property(e => e.Ethnicity).HasColumnName("ethnicity");

                entity.Property(e => e.FamilySize).HasColumnName("family_size");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(50)
                    .HasColumnName("father_name");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.GrandName)
                    .HasMaxLength(50)
                    .HasColumnName("grand_name");

                entity.Property(e => e.HardshipAllowance).HasColumnName("hardship_allowance");

                entity.Property(e => e.HealthStatus).HasColumnName("Health_Status");

                entity.Property(e => e.HousingAllowance).HasColumnName("housing_allowance");

                entity.Property(e => e.IsHired).HasColumnName("Is_Hired");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(75)
                    .HasColumnName("job_title");

                entity.Property(e => e.Kebele).HasMaxLength(15);

                entity.Property(e => e.LicenseGrade).HasColumnName("license_grade");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.MaritalStatus).HasColumnName("marital_status");

                entity.Property(e => e.MotherTongue).HasColumnName("mother_tongue");

                entity.Property(e => e.Nationality).HasColumnName("nationality");

                entity.Property(e => e.Occupation).HasColumnName("occupation");

                entity.Property(e => e.POBox)
                    .HasMaxLength(50)
                    .HasColumnName("p_o_box");

                entity.Property(e => e.PassportNo)
                    .HasMaxLength(50)
                    .HasColumnName("passport_no");

                entity.Property(e => e.PersonAddress)
                    .HasMaxLength(255)
                    .HasColumnName("person_address");

                entity.Property(e => e.PersonId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("person_id");

                entity.Property(e => e.Photo)
                    .HasColumnType("image")
                    .HasColumnName("photo");

                entity.Property(e => e.PositionCode)
                    .HasMaxLength(50)
                    .HasColumnName("position_code");

                entity.Property(e => e.Region).HasColumnName("region");

                entity.Property(e => e.Remark)
                    .HasColumnType("ntext")
                    .HasColumnName("remark");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.Property(e => e.SelectionCriteria).HasColumnName("Selection_Criteria");

                entity.Property(e => e.Sex).HasColumnName("sex");

                entity.Property(e => e.StaffCode)
                    .HasMaxLength(15)
                    .HasColumnName("staff_code");

                entity.Property(e => e.TelHome)
                    .HasMaxLength(50)
                    .HasColumnName("tel_home");

                entity.Property(e => e.TelOffDirect1)
                    .HasMaxLength(50)
                    .HasColumnName("tel_off_direct1");

                entity.Property(e => e.TelOffDirect2)
                    .HasMaxLength(50)
                    .HasColumnName("tel_off_direct2");

                entity.Property(e => e.TelOffExt1)
                    .HasMaxLength(50)
                    .HasColumnName("tel_off_ext1");

                entity.Property(e => e.Town).HasColumnName("town");

                entity.Property(e => e.TransportAllowance).HasColumnName("transport_allowance");

                entity.Property(e => e.WaitingRank).HasColumnName("Waiting_Rank");

                entity.Property(e => e.Worede).HasMaxLength(15);

                entity.Property(e => e.Zone).HasMaxLength(15);
            });

            modelBuilder.Entity<TblApplicantEducationHistory>(entity =>
            {
                entity.HasKey(e => e.AppEduHisId);

                entity.ToTable("tblApplicantEducationHistory");

                entity.Property(e => e.AppEduHisId)
                    .ValueGeneratedNever()
                    .HasColumnName("AppEduHisID");

                entity.Property(e => e.AffAactionWomen).HasColumnName("Aff_AactionWomen");

                entity.Property(e => e.AffAactionforHandicap).HasColumnName("Aff_AactionforHandicap");

                entity.Property(e => e.AffAactionforNationsNationalities).HasColumnName("Aff_AactionforNationsNationalities");

                entity.Property(e => e.AffActNotGivenReason)
                    .HasMaxLength(400)
                    .HasColumnName("Aff_Act_NotGivenReason");

                entity.Property(e => e.AffirDocNotAttachedReason)
                    .HasMaxLength(400)
                    .HasColumnName("Affir_Doc_NotAttachedReason");

                entity.Property(e => e.AffirmativeDocAttached).HasColumnName("AffirmativeDoc_Attached");

                entity.Property(e => e.CertificateObtained)
                    .HasMaxLength(50)
                    .HasColumnName("certificate_obtained");

                entity.Property(e => e.EducationType).HasColumnName("education_type");

                entity.Property(e => e.FieldOfStudy)
                    .HasMaxLength(50)
                    .HasColumnName("field_of_study");

                entity.Property(e => e.FullAddress).HasMaxLength(400);

                entity.Property(e => e.GivenByTheOrg).HasColumnName("Given_by_the_Org");

                entity.Property(e => e.Gpa).HasColumnName("gpa");

                entity.Property(e => e.Institution)
                    .HasMaxLength(150)
                    .HasColumnName("institution");

                entity.Property(e => e.IsEducationRelatedWithJob).HasColumnName("Is_Education_Related_with_Job");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .HasColumnName("location");

                entity.Property(e => e.NetDuration)
                    .HasMaxLength(50)
                    .HasColumnName("net_duration");

                entity.Property(e => e.NotAttachedReson).HasMaxLength(400);

                entity.Property(e => e.PeriodFrom)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("period_from");

                entity.Property(e => e.PeriodTo)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("period_to");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .HasColumnName("remark");

                entity.Property(e => e.SeqNo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("seq_no");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.Sponsor).HasMaxLength(50);

                entity.HasOne(d => d.App)
                    .WithMany(p => p.TblApplicantEducationHistories)
                    .HasForeignKey(d => d.AppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblApplicantEducationHistory_tblApplicant");
            });

            modelBuilder.Entity<TblApplicantEmploymentHistory>(entity =>
            {
                entity.HasKey(e => e.AppEmploymentId);

                entity.ToTable("tblApplicantEmploymentHistory");

                entity.Property(e => e.AppEmploymentId).ValueGeneratedNever();

                entity.Property(e => e.DateFrom)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("date_from");

                entity.Property(e => e.DateTermination)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("date_termination");

                entity.Property(e => e.DateTo)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("date_to");

                entity.Property(e => e.EducationLevel).HasMaxLength(50);

                entity.Property(e => e.EmpStatus).HasColumnName("emp_status");

                entity.Property(e => e.FieldofStudy).HasMaxLength(50);

                entity.Property(e => e.Institution)
                    .HasMaxLength(50)
                    .HasColumnName("institution");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(255)
                    .HasColumnName("job_title");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .HasColumnName("location");

                entity.Property(e => e.NetDuration)
                    .HasMaxLength(50)
                    .HasColumnName("net_duration");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .HasColumnName("remark");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.Property(e => e.SeqNo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("seq_no");

                entity.Property(e => e.TaxPaymentLetterNo)
                    .HasMaxLength(50)
                    .HasColumnName("tax_payment_letter_no");

                entity.Property(e => e.TerminationReason)
                    .HasMaxLength(255)
                    .HasColumnName("termination_reason");

                entity.HasOne(d => d.App)
                    .WithMany(p => p.TblApplicantEmploymentHistories)
                    .HasForeignKey(d => d.AppId)
                    .HasConstraintName("FK_tblApplicantEmploymentHistory_tblApplicant");
            });

            modelBuilder.Entity<TblApplicantExam>(entity =>
            {
                entity.HasKey(e => e.ApplicantExamGuid);

                entity.ToTable("tblApplicantExam");

                entity.Property(e => e.ApplicantExamGuid).ValueGeneratedNever();

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .HasColumnName("SessionMAC");

                entity.HasOne(d => d.App)
                    .WithMany(p => p.TblApplicantExams)
                    .HasForeignKey(d => d.AppId)
                    .HasConstraintName("FK_tblApplicantExam_tblApplicant");
            });

            modelBuilder.Entity<TblApplicantInterviewResult>(entity =>
            {
                entity.HasKey(e => e.AppExamResuId);

                entity.ToTable("tblApplicantInterviewResult");

                entity.Property(e => e.AppExamResuId)
                    .ValueGeneratedNever()
                    .HasColumnName("AppExamResuID");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .HasColumnName("SessionMAC");

                entity.HasOne(d => d.App)
                    .WithMany(p => p.TblApplicantInterviewResults)
                    .HasForeignKey(d => d.AppId)
                    .HasConstraintName("FK_tblApplicantInterviewResult_tblApplicant");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.TblApplicantInterviewResults)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_tblApplicantInterviewResult_tblPosition");
            });

            modelBuilder.Entity<TblApplicantTrainingHistory>(entity =>
            {
                entity.HasKey(e => e.AppTrainHisId);

                entity.ToTable("tblApplicantTrainingHistory");

                entity.Property(e => e.AppTrainHisId).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(400)
                    .HasColumnName("address");

                entity.Property(e => e.Budget).HasColumnName("budget");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(75)
                    .HasColumnName("contact_person");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(20)
                    .HasColumnName("course_name");

                entity.Property(e => e.Duration)
                    .HasMaxLength(25)
                    .HasColumnName("duration");

                entity.Property(e => e.Expense).HasColumnName("expense");

                entity.Property(e => e.Institution)
                    .HasMaxLength(30)
                    .HasColumnName("institution");

                entity.Property(e => e.IsTrainigRelatedWithJob).HasColumnName("Is_Trainig_Related_with_Job");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .HasColumnName("location");

                entity.Property(e => e.OtherCost).HasColumnName("other_cost");

                entity.Property(e => e.PercentCovered).HasColumnName("percent_covered");

                entity.Property(e => e.PeriodFrom)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("period_from");

                entity.Property(e => e.PeriodTo)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("period_to");

                entity.Property(e => e.PointsScored)
                    .HasMaxLength(50)
                    .HasColumnName("points_scored");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .HasColumnName("remark");

                entity.Property(e => e.SeqNo).HasColumnName("seq_no");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.Sponsor)
                    .HasMaxLength(30)
                    .HasColumnName("sponsor");

                entity.Property(e => e.TotalCost).HasColumnName("total_cost");

                entity.Property(e => e.TrainingNature).HasColumnName("training_nature");

                entity.Property(e => e.TrainingType).HasColumnName("training_type");

                entity.HasOne(d => d.App)
                    .WithMany(p => p.TblApplicantTrainingHistories)
                    .HasForeignKey(d => d.AppId)
                    .HasConstraintName("FK_tblApplicantTrainingHistory_tblApplicant");
            });

            modelBuilder.Entity<TblDemotion>(entity =>
            {
                entity.HasKey(e => e.EmpDemoId);

                entity.ToTable("tblDemotion");

                entity.Property(e => e.EmpDemoId).ValueGeneratedNever();

                entity.Property(e => e.Ddate)
                    .HasColumnType("datetime")
                    .HasColumnName("DDate");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Fpost)
                    .HasMaxLength(100)
                    .HasColumnName("FPost");

                entity.Property(e => e.Punishment).HasMaxLength(200);

                entity.Property(e => e.Referense).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(50);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.Tpost)
                    .HasMaxLength(100)
                    .HasColumnName("TPost");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblDemotions)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDemotion_EmployeeRegistration");
            });

            modelBuilder.Entity<TblEducationHistory>(entity =>
            {
                entity.HasKey(e => e.EmpEduHisId);

                entity.ToTable("tblEducationHistory");

                entity.Property(e => e.EmpEduHisId).ValueGeneratedNever();

                entity.Property(e => e.CertificateObtained)
                    .HasMaxLength(50)
                    .HasColumnName("certificate_obtained");

                entity.Property(e => e.EducationType).HasColumnName("education_type");

                entity.Property(e => e.FieldOfStudy)
                    .HasMaxLength(50)
                    .HasColumnName("field_of_study");

                entity.Property(e => e.FullAddress).HasMaxLength(400);

                entity.Property(e => e.GivenByTheOrg).HasColumnName("Given_by_the_Org");

                entity.Property(e => e.Gpa).HasColumnName("gpa");

                entity.Property(e => e.Institution)
                    .HasMaxLength(150)
                    .HasColumnName("institution");

                entity.Property(e => e.IsEducationRelatedWithJob).HasColumnName("Is_Education_Related_with_Job");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .HasColumnName("location");

                entity.Property(e => e.NetDuration)
                    .HasMaxLength(50)
                    .HasColumnName("net_duration");

                entity.Property(e => e.NotAttachedReson).HasMaxLength(400);

                entity.Property(e => e.PeriodFrom)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("period_from");

                entity.Property(e => e.PeriodTo)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("period_to");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .HasColumnName("remark");

                entity.Property(e => e.SeqNo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("seq_no");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.Sponsor).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblEducationHistories)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEducationHistory_EmployeeRegistration");
            });

            modelBuilder.Entity<TblEmployeeAddress>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("tblEmployeeAddress");

                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.HomeTel).HasMaxLength(50);

                entity.Property(e => e.HouseNo).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.OfficeTel).HasMaxLength(50);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.SubCity).HasMaxLength(50);

                entity.Property(e => e.Woreda).HasMaxLength(50);

                entity.Property(e => e.ZipCode).HasMaxLength(50);
            });

            modelBuilder.Entity<TblEmployeeEducation>(entity =>
            {
                entity.HasKey(e => e.EmpEduId);

                entity.ToTable("tblEmployeeEducation");

                entity.Property(e => e.EmpEduId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Credential).HasMaxLength(50);

                entity.Property(e => e.EducationLev).HasMaxLength(50);

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Field).HasMaxLength(50);

                entity.Property(e => e.Fyear)
                    .HasMaxLength(50)
                    .HasColumnName("FYear");

                entity.Property(e => e.Institute).HasMaxLength(50);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.Tyear)
                    .HasMaxLength(50)
                    .HasColumnName("TYear");
            });

            modelBuilder.Entity<TblEmployeeFamily>(entity =>
            {
                entity.HasKey(e => e.EmpFamId);

                entity.ToTable("tblEmployeeFamily");

                entity.Property(e => e.EmpFamId).ValueGeneratedNever();

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Dependancy).HasMaxLength(50);

                entity.Property(e => e.FamilyName).HasMaxLength(128);

                entity.Property(e => e.RelationType).HasMaxLength(50);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .HasColumnName("SessionMAC");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblEmployeeFamilies)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmployeeFamily_EmployeeRegistration");
            });

            modelBuilder.Entity<TblEmployeeLanguage>(entity =>
            {
                entity.HasKey(e => e.EmpLangId);

                entity.ToTable("tblEmployeeLanguage");

                entity.Property(e => e.EmpLangId).ValueGeneratedNever();

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Language).HasMaxLength(50);

                entity.Property(e => e.Reading).HasMaxLength(50);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.Speaking).HasMaxLength(50);

                entity.Property(e => e.Writing).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblEmployeeLanguages)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmployeeLanguage_EmployeeRegistration");
            });

            modelBuilder.Entity<TblEmployeeOfficial>(entity =>
            {
                entity.HasKey(e => e.EmpOffId)
                    .HasName("PK_tblEmployeeOfficial_1");

                entity.ToTable("tblEmployeeOfficial");

                entity.Property(e => e.EmpOffId).ValueGeneratedNever();

                entity.Property(e => e.ContractEndDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfHire).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployementType).HasMaxLength(50);

                entity.Property(e => e.Grade).HasMaxLength(50);

                entity.Property(e => e.JobTitle).HasMaxLength(50);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.State).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblEmployeeOfficials)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmployeeOfficial_EmployeeRegistration");
            });

            modelBuilder.Entity<TblEmployeeOnLeave>(entity =>
            {
                entity.HasKey(e => e.EmpLeavId);

                entity.ToTable("tblEmployeeOnLeave");

                entity.Property(e => e.EmpLeavId).ValueGeneratedNever();

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ReferenceNo).HasMaxLength(50);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblEmployeeOnLeaves)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmployeeOnLeave_EmployeeRegistration");

                entity.HasOne(d => d.LeaveTypeNavigation)
                    .WithMany(p => p.TblEmployeeOnLeaves)
                    .HasForeignKey(d => d.LeaveType)
                    .HasConstraintName("FK_tblEmployeeOnLeave_tblLeaveType");
            });

            modelBuilder.Entity<TblEmployeeRehire>(entity =>
            {
                entity.HasKey(e => e.EmpRehireId)
                    .HasName("PK_tblEmployeeReturn");

                entity.ToTable("tblEmployeeRehire");

                entity.Property(e => e.EmpRehireId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmpRehireID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ReferenceNo).HasMaxLength(50);

                entity.Property(e => e.RehireDate).HasColumnType("datetime");

                entity.Property(e => e.RehireReason).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(4000);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .HasColumnName("SessionMAC");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblEmployeeRehires)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmployeeRehire_EmployeeRegistration");
            });

            modelBuilder.Entity<TblEmployeeTerminate>(entity =>
            {
                entity.HasKey(e => e.EmpTermId);

                entity.ToTable("tblEmployeeTerminate");

                entity.Property(e => e.EmpTermId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmpTermID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Remark).HasMaxLength(4000);

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.TerminateDate).HasColumnType("datetime");

                entity.Property(e => e.TerminateReason).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblEmployeeTerminates)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmployeeTerminate_EmployeeRegistration");
            });

            modelBuilder.Entity<TblEmploymentHistory>(entity =>
            {
                entity.HasKey(e => e.EmpEmploymentId);

                entity.ToTable("tblEmploymentHistory");

                entity.Property(e => e.EmpEmploymentId).ValueGeneratedNever();

                entity.Property(e => e.DateFrom)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("date_from");

                entity.Property(e => e.DateTermination)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("date_termination");

                entity.Property(e => e.DateTo)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("date_to");

                entity.Property(e => e.EducationLevel).HasMaxLength(50);

                entity.Property(e => e.EmpStatus).HasColumnName("emp_status");

                entity.Property(e => e.FieldofStudy).HasMaxLength(50);

                entity.Property(e => e.Institution)
                    .HasMaxLength(50)
                    .HasColumnName("institution");

                entity.Property(e => e.InstitutionEng)
                    .HasMaxLength(50)
                    .HasColumnName("institutionEng");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(255)
                    .HasColumnName("job_title");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .HasColumnName("location");

                entity.Property(e => e.NetDuration)
                    .HasMaxLength(50)
                    .HasColumnName("net_duration");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .HasColumnName("remark");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.Property(e => e.SeqNo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("seq_no");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.TaxPaymentLetterNo)
                    .HasMaxLength(50)
                    .HasColumnName("tax_payment_letter_no");

                entity.Property(e => e.TerminationReason)
                    .HasMaxLength(255)
                    .HasColumnName("termination_reason");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblEmploymentHistories)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmploymentHistory_EmployeeRegistration");
            });

            modelBuilder.Entity<TblGrade>(entity =>
            {
                entity.HasKey(e => e.GradeId);

                entity.ToTable("tblGrade");

                entity.Property(e => e.GradeId)
                    .ValueGeneratedNever()
                    .HasColumnName("GradeID");

                entity.Property(e => e.GradeName).HasMaxLength(100);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .HasColumnName("SessionMAC");
            });

            modelBuilder.Entity<TblLeaveRequest>(entity =>
            {
                entity.HasKey(e => e.EmpLeaveRequestId);

                entity.ToTable("tblLeaveRequest");

                entity.Property(e => e.EmpLeaveRequestId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmpLeaveRequestID");

                entity.Property(e => e.ApproveDate).HasColumnType("datetime");

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.IsAnnualLeave).HasDefaultValueSql("((0))");

                entity.Property(e => e.LeaveType).HasMaxLength(50);

                entity.Property(e => e.Reason).HasMaxLength(200);

                entity.Property(e => e.ReferenceNo).HasMaxLength(50);

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.Property(e => e.ResumeWorkOn).HasColumnType("datetime");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblLeaveRequests)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLeaveRequest_EmployeeRegistration");
            });

            modelBuilder.Entity<TblLeaveType>(entity =>
            {
                entity.HasKey(e => e.LeaveTypeId);

                entity.ToTable("tblLeaveType");

                entity.Property(e => e.LeaveTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("LeaveTypeID");

                entity.Property(e => e.Condition).HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.LeaveType).HasMaxLength(50);

                entity.Property(e => e.NoOfDays).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Pay).HasMaxLength(50);
            });

            modelBuilder.Entity<TblPosition>(entity =>
            {
                entity.HasKey(e => e.PositionId);

                entity.ToTable("tblPosition");

                entity.Property(e => e.Ability).HasMaxLength(500);

                entity.Property(e => e.Character).HasMaxLength(500);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DutiesResponsiblities)
                    .HasMaxLength(4000)
                    .HasColumnName("duties_responsiblities");

                entity.Property(e => e.EducationDescription)
                    .HasMaxLength(500)
                    .HasColumnName("education_description");

                entity.Property(e => e.EducationLevel)
                    .HasMaxLength(4000)
                    .HasColumnName("education_level");

                entity.Property(e => e.EducationType)
                    .HasMaxLength(4000)
                    .HasColumnName("education_type");

                entity.Property(e => e.Experiences)
                    .HasMaxLength(4000)
                    .HasColumnName("experiences");

                entity.Property(e => e.GradeId).HasColumnName("grade_id");

                entity.Property(e => e.InitialSalary).HasColumnName("initial_salary");

                entity.Property(e => e.IsVacant).HasColumnName("Is_Vacant");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(255)
                    .HasColumnName("job_title");

                entity.Property(e => e.Knowledge).HasMaxLength(500);

                entity.Property(e => e.Occupation).HasColumnName("occupation");

                entity.Property(e => e.OccupationRank)
                    .HasMaxLength(15)
                    .HasColumnName("occupation_rank");

                entity.Property(e => e.PositionCode)
                    .HasMaxLength(50)
                    .HasColumnName("position_code");

                entity.Property(e => e.Remark)
                    .HasMaxLength(4000)
                    .HasColumnName("remark");

                entity.Property(e => e.SalaryCeiling).HasColumnName("salary_ceiling");

                entity.Property(e => e.SalaryIncrement).HasColumnName("salary_increment");

                entity.Property(e => e.Skill).HasMaxLength(500);
            });

            modelBuilder.Entity<TblPromotion>(entity =>
            {
                entity.HasKey(e => e.EmpPromotionId);

                entity.ToTable("tblPromotion");

                entity.Property(e => e.EmpPromotionId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmpPromotionID");

                entity.Property(e => e.Award).HasMaxLength(200);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Fdept)
                    .HasMaxLength(50)
                    .HasColumnName("FDept");

                entity.Property(e => e.Fgrade)
                    .HasMaxLength(50)
                    .HasColumnName("FGrade");

                entity.Property(e => e.Fjob)
                    .HasMaxLength(50)
                    .HasColumnName("FJob");

                entity.Property(e => e.Pdate)
                    .HasColumnType("datetime")
                    .HasColumnName("PDate");

                entity.Property(e => e.ReferenceNo).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(400);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .HasColumnName("SessionMAC");

                entity.Property(e => e.Tdept)
                    .HasMaxLength(50)
                    .HasColumnName("TDept");

                entity.Property(e => e.Tgrade)
                    .HasMaxLength(50)
                    .HasColumnName("TGrade");

                entity.Property(e => e.Tjob)
                    .HasMaxLength(50)
                    .HasColumnName("TJob");

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblPromotions)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPromotion_EmployeeRegistration");
            });

            modelBuilder.Entity<TblSalaryGrade>(entity =>
            {
                entity.HasKey(e => e.GradeId);

                entity.ToTable("tblSalaryGrade");

                entity.Property(e => e.GradeId)
                    .HasMaxLength(50)
                    .HasColumnName("GradeID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.LeaveType).HasMaxLength(50);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
