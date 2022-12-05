using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class tblLookup
    {
        [Key]
        public int Id { get; set; }

        public string? Code { get; set; }

        public string? Description { get; set; }

        public string? Amdescription { get; set; }

        public string? Parent { get; set; }

        public string? Tigrigna { get; set; }

        public string? AfanOromo { get; set; }

        public string? Afar { get; set; }

        public string? Somali { get; set; }

        public string? Arabic { get; set; }
    }
}
