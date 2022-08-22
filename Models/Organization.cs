using System;
using System.Collections.Generic;

namespace DDU.Models
{
    public partial class Organization
    {
        public Guid OrgGuid { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? DescriptionAm { get; set; }
        public int YearEstablished { get; set; }
        public string ParentAdministrationCode { get; set; } = null!;
        public string OrgType { get; set; } = null!;
        public bool IsActive { get; set; }
        public string? Telephone { get; set; }
        public string? Pobox { get; set; }
        public string? Email { get; set; }
        public string? WebUrl { get; set; }
        public byte[]? Logo { get; set; }
        public string? ZoneCode { get; set; }
        public string? WeredaCode { get; set; }
        public string? OrgProclamationNo { get; set; }
        public string? SessionId { get; set; }
        public string? SessionIp { get; set; }
        public string? SessionMac { get; set; }
    }
}
