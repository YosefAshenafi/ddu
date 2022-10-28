namespace DDU.Models
{
    public class ViewDailyLabourer
    {
        public IEnumerable<DailyLabourer>? Checked { get; set; }
        public IEnumerable<DailyLabourer>? Approved { get; set; }
        public IEnumerable<DailyLabourer>? Paid { get; set; }
    }
}
