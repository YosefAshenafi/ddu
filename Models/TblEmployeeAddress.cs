using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class TblEmployeeAddress
    {
        public Guid EmployeeId { get; set; }
        public string? City { get; set; }
        public string? SubCity { get; set; }
        public string? Woreda { get; set; }
        public string? HouseNo { get; set; }
        public string? ZipCode { get; set; }
        public string? HomeTel { get; set; }
        public string? Mobile { get; set; }
        public string? OfficeTel { get; set; }
        public string? Email { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }
    }
}
