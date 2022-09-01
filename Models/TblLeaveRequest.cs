using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public partial class TblLeaveRequest
    {
        [Key]
        public Guid EmpLeaveRequestId { get; set; }
        public Guid EmployeeId { get; set; }
        public string ReferenceNo { get; set; } = null!;
        public string? LeaveType { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? ApproveDate { get; set; }
        public DateTime? ResumeWorkOn { get; set; }
        public double? AvailableDays { get; set; }
        public double? NoOfRequestedDays { get; set; }
        public double? RemainingDays { get; set; }
        public double? LeaveBalance { get; set; }
        public string? Reason { get; set; }
        public string? ApprovedBy { get; set; }
        public int? IsAnnualLeave { get; set; }
    }
}
