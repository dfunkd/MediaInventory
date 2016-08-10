namespace MediaInventory.Data
{
    public partial class Customer
    {
        public string FullName
        {
            get { return string.Format("{0}, {1}", LastName, FirstName); }
        }
    }
}