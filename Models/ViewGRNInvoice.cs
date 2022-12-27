namespace DDU.Models
{
    public class ViewGRNInvoice
    {
        public EmployeeRegistration? Registration { get; set; }
        public InvReceive? receive { get; set; }
        public InvStore? store { get; set; }
        public InvSupplier? supplier { get; set; }
        public IEnumerable<Vw_ReceiveDetail>? vw_ReceiveDetail { get; set; }
    }
}
