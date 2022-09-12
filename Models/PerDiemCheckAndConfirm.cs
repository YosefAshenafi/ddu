using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public partial class PerDiemCheckAndConfirm
    {
        [Key]
        public Guid CheckandconfirmId { get; set; }
        public Guid RequestPerDimId { get; set; }
        public string? Title { get; set; }
        public int? DepartmentId { get; set; }
        public Guid? EmployeeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? HotelPerDiem { get; set; }
        public double? TravelPerDiem { get; set; }
        public string? CheckAndConfirmBy { get; set; }
        public bool? IsCheckAndConfirm { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }
    }
}
