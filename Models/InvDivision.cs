using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvDivision
    {
        [Key]
        public int DivID { get; set; }

        public string DivCode { get; set; }

        public string DivName { get; set; }

        public string DivAddress { get; set; }

        public string SessionID { get; set; }

        public string SessionIP { get; set; }

        public string SessionMAC { get; set; }
    }
}
