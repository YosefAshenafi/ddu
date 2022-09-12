using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DDU.Models
{
    public partial class PerDiemRequest
    {
        
        [Key]
        public Guid RequestPerDimId { get; set; }
        public string? Title { get; set; }
        public int? DepartmentID { get; set; }
        public Guid? EmployeeID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? HotelPerDiem { get; set; } 
        public double? TravelPerDiem { get; set; } 
        public string? SessionId { get; set; } = "";
        public string? SessionIp { get; set; } = "";
        public string? SessionMac { get; set; } = "";

        [NotMapped]
        public List<SelectListItem>? ListEmployees { set; get; }

        [NotMapped]
        public List<SelectListItem>? ListDepartment { set; get; }

        [NotMapped]
        public string? DepartmentName { set; get; }

        [NotMapped]
        public string? EmployeeName { set; get; }
    }
}
