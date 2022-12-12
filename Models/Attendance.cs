using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class Attendance
    {
        [Key]
        public Guid? AttendanceID { get; set; }

        public Guid? EmployeeID { get; set; }

        public string? EmployeeName { get; set; }

        public string? Department { get; set; }

        public int? TimeLineType { get; set; }

        public DateTime? CheckIn { get; set; }

        
        public DateTime? Checkout { get; set; }

        public int? NetMinutes { get; set; }

        
        public string? Shift { get; set; }

        public string? Status { get; set; }

        public string? Remark { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Date { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }


    }
}
