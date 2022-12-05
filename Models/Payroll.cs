using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
	public class Payroll
	{
        [Key]
        public Guid PayrollID { get; set; }

        public Guid EmployeeID { get; set; }

        public int IDNo { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public byte Sex { get; set; }

        public int DepartmentID { get; set; }

        public int SubDepartmentID { get; set; }

        public int ShiftGroupID { get; set; }

        public DateTime HireDate { get; set; }

        public Guid SubGradeID { get; set; }

        public decimal BasicSalary { get; set; }

        public decimal HourlyEarning { get; set; }

        public decimal AbsentHours { get; set; }

        public decimal PermissionHours { get; set; }

        public decimal LeaveWithoutPayHours { get; set; }

        public decimal MonthlyAttendanceHours { get; set; }

        public decimal MonthlyWorkedHours { get; set; }

        public decimal HolidayHours { get; set; }

        public decimal AdvanceHours { get; set; }

        public decimal CompletionToContractHours { get; set; }

        public decimal TotalWorkedHours { get; set; }

        public decimal BasicEarning { get; set; }

        public decimal PenaltyHours { get; set; }

        public decimal PenaltyDeduction { get; set; }

        public decimal PenaltyInAmount { get; set; }

        public decimal AdvancePaidAmount { get; set; }

        public decimal OtherDeduction { get; set; }

        public decimal StaffRecivable { get; set; }

        public decimal IncrementHours { get; set; }

        public decimal IncrementPayment { get; set; }

        public decimal NationalHolydayOTHours { get; set; }

        public decimal NationalHolydayOTPayment { get; set; }

        public decimal WeekdayNightOTHours { get; set; }

        public decimal WeekdayNightOTPayment { get; set; }

        public decimal WeekdayOTHours { get; set; }

        public decimal WeekdayOTPayment { get; set; }

        public decimal SundayOTHours { get; set; }

        public decimal SundayOTPayment { get; set; }

        public decimal PrePaidIncentive { get; set; }

        public decimal MonthlyIncentivePayment { get; set; }

        public decimal AnnualLeaveHours { get; set; }

        public decimal SickLeaveHours { get; set; }

        public decimal MaternityLeaveHours { get; set; }

        public decimal OtherLeaveHours { get; set; }

        public decimal TransportAllowance { get; set; }

        public decimal PhoneAllowance { get; set; }

        public decimal OtherAllowance { get; set; }

        public decimal Pension { get; set; }

        public decimal GrossEarning { get; set; }

        public decimal Tax { get; set; }

        public decimal TotalDeduction { get; set; }

        public decimal NetPayment { get; set; }

        public byte PayrollMonth { get; set; }

        public int PayrollYear { get; set; }

        public DateTime PaymentDate { get; set; }

        public bool IsPaid { get; set; }

        public int PayrollVersion { get; set; }

        public decimal BackPaymentHours { get; set; }

        public decimal BackPaymentPayment { get; set; }

        public DateTime ProcessedOn { get; set; }

        public string SessionID { get; set; }

        public string SessionIP { get; set; }

        public string SessionMAC { get; set; }

    }
}
