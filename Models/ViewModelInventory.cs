namespace DDU.Models
{
    public class ViewModelInventory
    {
        public IEnumerable<InvSupplier> Suppliers { get; set; }
        public IEnumerable<InvEquipment> Equipment { get; set; }
    }
}
