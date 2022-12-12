using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvItemFamily
    {
        [Key]
        public int FamID { get; set; }

        public string FamCode { get; set; }

        public string FamName { get; set; }

        public string SessionID { get; set; }

        public string SessionIP { get; set; }

        public string SessionMAC { get; set; }
    }
}
