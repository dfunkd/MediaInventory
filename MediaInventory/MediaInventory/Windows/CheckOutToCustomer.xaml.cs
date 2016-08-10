using MediaInventory.Data;
using MediaInventory.Resources;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace MediaInventory.Windows
{
    public partial class CheckOutToCustomer : Window
    {
        #region Dependency Properties
        #region Filter
        public static readonly DependencyProperty FilterProperty = DependencyProperty.Register("Filter", typeof(string), typeof(CheckOutToCustomer),
            new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(OnFilterChanged)));
        public string Filter
        {
            get { return (string)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }
        private static void OnFilterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CheckOutToCustomer)d).OnFilterChanged(e);
        }
        protected virtual void OnFilterChanged(DependencyPropertyChangedEventArgs e)
        {
            //dgCustomers.ItemsSource = new ObservableCollection<Customer>(Customers.Where(x => x.FullName != null && x.FullName.ToLower().Contains(Filter)));
            RefreshCollectionView();
        }
        #endregion
        #region SelectedCustomer
        public static readonly DependencyProperty SelectedCustomerProperty = DependencyProperty.Register("SelectedCustomer", typeof(Customer), typeof(CheckOutToCustomer), new FrameworkPropertyMetadata(null, OnSelectedCustomerChanged));
        public Customer SelectedCustomer
        {
            get { return (Customer)GetValue(SelectedCustomerProperty); }
            set { SetValue(SelectedCustomerProperty, value); }
        }
        private static void OnSelectedCustomerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CheckOutToCustomer)d).OnSelectedCustomerChanged(e);
        }
        protected virtual void OnSelectedCustomerChanged(DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion
        #endregion
        #region Routed Commands
        #region CancelCheckout
        public static RoutedUICommand CancelCheckout = new RoutedUICommand("Cancel", "CancelCheckout", typeof(CheckOutToCustomer));
        private void CancelCheckoutExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
        private void CanCancelCheckout(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        #endregion
        #region OkCheckout
        public static RoutedUICommand OkCheckout = new RoutedUICommand("Ok", "OkCheckout", typeof(CheckOutToCustomer));
        private void OkCheckoutExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
        private void CanOkCheckout(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Globals.Default.SelectedCustomer != null;
        }
        #endregion
        #endregion
        public CheckOutToCustomer()
        {
            InitializeComponent();
            Globals.Default.SelectedCustomer = null;
            Loaded += (s, a) =>
            {
                CollectionViewSource cvs = (CollectionViewSource)FindResource("cvsCustomers");
                cvs.Source = new ObservableCollection<Customer>(Helpers.InventoryWindow.InventoryEntity.Customers);
                cvs.View.Filter = CustomerFilter;
            };
        }
        #region Events
        private void DataGridCell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            if (cell != null && !cell.IsEditing && !cell.IsReadOnly)
            {
                if (!cell.IsFocused)
                    cell.Focus();
                DataGrid dataGrid = Helpers.FindVisualParent<DataGrid>(cell);
                if (dataGrid != null)
                {
                    if (dataGrid.SelectionUnit != DataGridSelectionUnit.FullRow)
                    {
                        if (!cell.IsSelected)
                            cell.IsSelected = true;
                    }
                    else
                    {
                        DataGridRow row = Helpers.FindVisualParent<DataGridRow>(cell);
                        if (row != null && !row.IsSelected)
                            row.IsSelected = true;
                    }
                }
            }
        }
        private void dgCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedCustomer = dgCustomers.SelectedItem as Customer;
            if (SelectedCustomer != Globals.Default.SelectedCustomer)
                Globals.Default.SelectedCustomer = SelectedCustomer;
        }
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        #endregion
        #region Functions
        public bool CustomerFilter(object item)
        {
            Customer customer = item as Customer;
            return customer != null && customer.FullName != null && customer.FullName.ToLower().Contains(Filter.ToLower());
        }
        private void RefreshCollectionView()
        {
            CollectionViewSource cvs = (CollectionViewSource)FindResource("cvsCustomers");
            cvs.View.Refresh();
        }
        #endregion

    }
}