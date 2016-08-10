namespace MediaInventory.Data
{
    public partial class CheckOutHistory
    {
        public bool IsCheckedOut
        {
            get { return CheckInDate == null; }
        }
    }
}