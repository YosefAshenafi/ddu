using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public partial class TblLeaveType
    {
        [Key]
        public int LeaveTypeId { get; set; }
        public string? LeaveType { get; set; }
        public string? Pay { get; set; }
        public decimal? NoOfDays { get; set; }
        public string? Description { get; set; }
        public string? Condition { get; set; }
        public int? IsDeleted { get; set; }
    }
}
