using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvItemType
    {
        public int FamilyID { get; set; }

        [Key]
        public int TypeID { get; set; }

        public string TypeCode { get; set; }

        public string Name { get; set; }

        public string SessionID { get; set; }

        public string SessionIP { get; set; }

        public string SessionMAC { get; set; }
    }
}
