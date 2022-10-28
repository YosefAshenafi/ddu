using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DDU.Models
{
    public class GeneratePayroll
    {
        [Key]
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? HDate { get; set; }
        public int? FDate { get; set; }
        public int? TDate { get; set; }
        public bool? insert { get; set; } = true;
        static string strConnectionString = "User Id=sa;Password=Ahmi#comp#1;Server=.;Database=DDUDB;";


    }
}
