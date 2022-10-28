using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class AspNetRoles
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string? NormalizedName { get; set; }
    }
}
