using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvFixedAsset
    {
        [Key]
        public int FixID { get; set; }

        public string FixCode { get; set; }

        public string FixName { get; set; }

        public int AccID { get; set; }

        public string SessionID { get; set; }

        public string SessionIP { get; set; }

        public string SessionMAC { get; set; }

    }
}
