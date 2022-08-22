using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblApplicant
    {
        public TblApplicant()
        {
            TblApplicantEducationHistories = new HashSet<TblApplicantEducationHistory>();
            TblApplicantEmploymentHistories = new HashSet<TblApplicantEmploymentHistory>();
            TblApplicantExams = new HashSet<TblApplicantExam>();
            TblApplicantInterviewResults = new HashSet<TblApplicantInterviewResult>();
            TblApplicantTrainingHistories = new HashSet<TblApplicantTrainingHistory>();
        }

        public Guid AppId { get; set; }
        public int PersonId { get; set; }
        public string? StaffCode { get; set; }
        public string? FirstName { get; set; }
        public string? FatherName { get; set; }
        public string? GrandName { get; set; }
        public double? Allowance { get; set; }
        public double? Salary { get; set; }
        public double? TransportAllowance { get; set; }
        public double? HardshipAllowance { get; set; }
        public double? HousingAllowance { get; set; }
        public double? CardFee { get; set; }
        public int? Sex { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public int? MaritalStatus { get; set; }
        public int? FamilySize { get; set; }
        public int? Nationality { get; set; }
        public int? Town { get; set; }
        public int? Region { get; set; }
        public string? POBox { get; set; }
        public string? PersonAddress { get; set; }
        public string? TelHome { get; set; }
        public string? TelOffDirect1 { get; set; }
        public string? TelOffDirect2 { get; set; }
        public string? TelOffExt1 { get; set; }
        public string? PassportNo { get; set; }
        public int? LicenseGrade { get; set; }
        public int? EducationLevel { get; set; }
        public string? EducationDescription { get; set; }
        public string? JobTitle { get; set; }
        public int? Occupation { get; set; }
        public string? PositionCode { get; set; }
        public string? Remark { get; set; }
        public int? MotherTongue { get; set; }
        public int? Ethnicity { get; set; }
        public int? Location { get; set; }
        public byte[]? Photo { get; set; }
        public double? CostSharingTotalAmount { get; set; }
        public double? CostSharingTotalPaid { get; set; }
        public double? CostSharingMonthlyPayment { get; set; }
        public int? HealthStatus { get; set; }
        public Guid? RankGuid { get; set; }
        public bool? IsTheoryTaken { get; set; }
        public bool? IsPracticalTaken { get; set; }
        public bool? IsInterviewTaken { get; set; }
        public bool? IsHired { get; set; }
        public int? SelectionCriteria { get; set; }
        public string? Zone { get; set; }
        public string? Worede { get; set; }
        public string? Kebele { get; set; }
        public int? WaitingRank { get; set; }

        public virtual ICollection<TblApplicantEducationHistory> TblApplicantEducationHistories { get; set; }
        public virtual ICollection<TblApplicantEmploymentHistory> TblApplicantEmploymentHistories { get; set; }
        public virtual ICollection<TblApplicantExam> TblApplicantExams { get; set; }
        public virtual ICollection<TblApplicantInterviewResult> TblApplicantInterviewResults { get; set; }
        public virtual ICollection<TblApplicantTrainingHistory> TblApplicantTrainingHistories { get; set; }
    }
}
