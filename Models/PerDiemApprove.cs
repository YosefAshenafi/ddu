using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public partial class PerDiemApprove
    {
        [Key]
        public Guid ApprovedId { get; set; } 
        public Guid CheckandconfirmId { get; set; }
        public string? Title { get; set; }
        public int? DepartmentId { get; set; }
        public Guid? EmployeeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? HotelPerDiem { get; set; }
        public double? TravelPerDiem { get; set; }
        public string? ApprovedBy { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsPaid { get; set; }        
        public double? Tax { get; set; }
        public double? Net { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }
    }
}
