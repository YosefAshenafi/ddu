using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class EmployeeRegistration
    {
        public EmployeeRegistration()
        {
            AdvancePaids = new HashSet<AdvancePaid>();
            Allowances = new HashSet<Allowance>();
            EmployeeAwards = new HashSet<EmployeeAward>();
            EmployeeDeductions = new HashSet<EmployeeDeduction>();
            EmployeeEvaluationPeriods = new HashSet<EmployeeEvaluationPeriod>();
            EmployeePerdiemRequests = new HashSet<EmployeePerdiemRequest>();
            EmployeePunishments = new HashSet<EmployeePunishment>();
            EmployeeShifts = new HashSet<EmployeeShift>();
            EmployeeStatusChanges = new HashSet<EmployeeStatusChange>();
            EmployeeTimeLines = new HashSet<EmployeeTimeLine>();
            EmployeeTransfers = new HashSet<EmployeeTransfer>();
            StaffRecivables = new HashSet<StaffRecivable>();
            TblDemotions = new HashSet<TblDemotion>();
            TblEducationHistories = new HashSet<TblEducationHistory>();
            TblEmployeeFamilies = new HashSet<TblEmployeeFamily>();
            TblEmployeeLanguages = new HashSet<TblEmployeeLanguage>();
            TblEmployeeOfficials = new HashSet<TblEmployeeOfficial>();
            TblEmployeeOnLeaves = new HashSet<TblEmployeeOnLeave>();
            TblEmployeeRehires = new HashSet<TblEmployeeRehire>();
            TblEmployeeTerminates = new HashSet<TblEmployeeTerminate>();
            TblEmploymentHistories = new HashSet<TblEmploymentHistory>();
            TblLeaveRequests = new HashSet<TblLeaveRequest>();
            TblPromotions = new HashSet<TblPromotion>();
        }

        public Guid EmployeeId { get; set; }
        public int Idno { get; set; }
        public string? Title { get; set; }
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string? LastName { get; set; }
        public byte? Sex { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? SubCityOrTownId { get; set; }
        public string? Kebele { get; set; }
        public string? HouseNo { get; set; }
        public string? NationalIdno { get; set; }
        public byte? Shift { get; set; }
        public string? Telephone { get; set; }
        public byte[]? Photo { get; set; }
        public string? Extension { get; set; }
        public int? ShiftGroupId { get; set; }
        public bool? NoPension { get; set; }
        public string? PensionAgencyId { get; set; }
        public DateTime? PensionApplicationDate { get; set; }
        public DateTime? PensionIdrecievedDate { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }

        public virtual ICollection<AdvancePaid> AdvancePaids { get; set; }
        public virtual ICollection<Allowance> Allowances { get; set; }
        public virtual ICollection<EmployeeAward> EmployeeAwards { get; set; }
        public virtual ICollection<EmployeeDeduction> EmployeeDeductions { get; set; }
        public virtual ICollection<EmployeeEvaluationPeriod> EmployeeEvaluationPeriods { get; set; }
        public virtual ICollection<EmployeePerdiemRequest> EmployeePerdiemRequests { get; set; }
        public virtual ICollection<EmployeePunishment> EmployeePunishments { get; set; }
        public virtual ICollection<EmployeeShift> EmployeeShifts { get; set; }
        public virtual ICollection<EmployeeStatusChange> EmployeeStatusChanges { get; set; }
        public virtual ICollection<EmployeeTimeLine> EmployeeTimeLines { get; set; }
        public virtual ICollection<EmployeeTransfer> EmployeeTransfers { get; set; }
        public virtual ICollection<StaffRecivable> StaffRecivables { get; set; }
        public virtual ICollection<TblDemotion> TblDemotions { get; set; }
        public virtual ICollection<TblEducationHistory> TblEducationHistories { get; set; }
        public virtual ICollection<TblEmployeeFamily> TblEmployeeFamilies { get; set; }
        public virtual ICollection<TblEmployeeLanguage> TblEmployeeLanguages { get; set; }
        public virtual ICollection<TblEmployeeOfficial> TblEmployeeOfficials { get; set; }
        public virtual ICollection<TblEmployeeOnLeave> TblEmployeeOnLeaves { get; set; }
        public virtual ICollection<TblEmployeeRehire> TblEmployeeRehires { get; set; }
        public virtual ICollection<TblEmployeeTerminate> TblEmployeeTerminates { get; set; }
        public virtual ICollection<TblEmploymentHistory> TblEmploymentHistories { get; set; }
        public virtual ICollection<TblLeaveRequest> TblLeaveRequests { get; set; }
        public virtual ICollection<TblPromotion> TblPromotions { get; set; }
    }
}
