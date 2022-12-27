using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class InvInventoryItem
    {
        public int NatureID { get; set; }

        public int FamID { get; set; }

        public int? TypeID { get; set; }

        public int DivisionID { get; set; }
        [Key]
        public int ItemID { get; set; }

        public string? ItemCode { get; set; }

        public string? ItemName { get; set; }

        public string? Description { get; set; }

        public int SeqNo { get; set; }

        public string? UnitMeasure { get; set; }

        public double UnitCost { get; set; }

        public double BegQty { get; set; }

        public double BegUnitCost { get; set; }

        public DateTime? BegDate { get; set; }

        public double? Quantity { get; set; }

        public decimal ReoredrPoint { get; set; }

        public string? PackageSize { get; set; }

        public bool IsActive { get; set; }

        public string? Image1Path { get; set; }

        public string? Image2Path { get; set; }

        public string? ManPartNo { get; set; }

        public int StoreID { get; set; }

        public string? Shelf { get; set; }

        public string? Row { get; set; }

        public string? Box { get; set; }

        public string? Remark { get; set; }

        public int StockAccId { get; set; }

        public double Minimum { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? LastUpdated { get; set; }



    }
}
