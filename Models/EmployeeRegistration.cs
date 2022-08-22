using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class EmployeeRegistration
    {
        [Key]
        public Guid? EmployeeID { get; set; }

        public string? Title { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string? LastName { get; set; }

        public byte? Sex { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }


        public DateTime? HireDate { get; set; }

        public int? SubCityOrTownID { get; set; }

        public string? Kebele { get; set; }

        public string? HouseNo { get; set; }

        public string? NationalIDNo { get; set; }

        public byte? Shift { get; set; }

        public string? Telephone { get; set; }

        public string? Extension { get; set; }

        public int? ShiftGroupID { get; set; }

        public bool? NoPension { get; set; }

        public string? Image1Path { get; set; } = "/images/employee/avatar-1.jpg";

        public string? PensionAgencyID { get; set; }

        public DateTime? PensionApplicationDate { get; set; }

        public DateTime? PensionIDRecievedDate { get; set; }

        public string? Designation { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }
    }
}
