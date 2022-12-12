using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvUnitMeasure
    {
        [Key]
        public string UnitMeasureCode { get; set; }

        public string Name { get; set; }

    }
}
