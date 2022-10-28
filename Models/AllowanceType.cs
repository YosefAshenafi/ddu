using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class AllowanceType
    {
        [Key]
        public int AllowanceTypeID { get; set; }

        public string? AllowanceTypeName { get; set; }

        public string? SessionID { get; set; }

        public string? SessionIP { get; set; }

        public string? SessionMAC { get; set; }
    }
}
