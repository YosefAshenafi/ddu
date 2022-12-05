using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class SalaryChange
    {
        [Key]
        public Guid SalaryChangeID { get; set; }

        public Guid EmployeeID { get; set; }

        public decimal Salary { get; set; }

        public DateTime? EffectiveDate { get; set; }

        public byte CurrencyID { get; set; }

        public string? Remark { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }
    }
}
