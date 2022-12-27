using System.ComponentModel.DataAnnotations;

namespace DDU.Models
{
    public class Vw_BinCard
    {
        public int TransactionID { get; set; }

        public string? Type { get; set; }

        [Key]
        public string UniqueValue { get; set; }

        public string StoreID { get; set; }

        public DateTime? OperationDate { get; set; }

        public string? ItemID { get; set; }

        public double Qty { get; set; }

        public double UnitPrice { get; set; }

        public int RowState { get; set; }

        public double Stockin { get; set; }

        public double Stockout { get; set; }

        public double Adjustment { get; set; }

        public double Balance { get; set; }

        public double Amount { get; set; }

        public double BalAmount { get; set; }

        public string? ItemName { get; set; }

        public string? Category { get; set; }
    }
}
