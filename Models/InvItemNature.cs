using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvItemNature
    {
        [Key]
        public int NatureID { get; set; }

        public string NatureCode { get; set; }

        public string NatureName { get; set; }

        public string SessionID { get; set; }

        public string SessionIP { get; set; }

        public string SessionMAC { get; set; }
    }
}
