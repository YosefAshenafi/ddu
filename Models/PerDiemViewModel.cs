using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class PerDiemViewModel
    {
        [Key]
        public Guid RequestPerDimId { get; set; }
        public Guid CheckandconfirmId { get; set; } 
        public Guid ApprovedId { get; set; }
        public string? Title { get; set; } = "";
        public int? DepartmentID { get; set; }
        public Guid? EmployeeID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? HotelPerDiem { get; set; } = 0.00;
        public double? TravelPerDiem { get; set; } = 0.00;
        public string? CheckAndConfirmBy { get; set; }
        public bool? IsCheckAndConfirm { get; set; } = false;
        public string? ApprovedBy { get; set; } = "";
        public bool? IsApproved { get; set; } = false;
        public bool? IsPaid { get; set; } = false;
        public double? Tax { get; set; }=0.00;
        public double? Net { get; set; }=0.00;
        public string? SessionId { get; set; } = "";
        public string? SessionIp { get; set; } = "";
        public string? SessionMac { get; set; } = "";
    }
}
