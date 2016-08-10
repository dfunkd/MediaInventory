using MediaInventory.Data;
using MediaInventory.Resources;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MediaInventory.UserControls
{
    public partial class SearchCustomers : UserControl
    {
        #region Dependency Properties
        #region COH
        public static readonly DependencyProperty COHProperty = DependencyProperty.Register("COH", typeof(CheckOutHistory), typeof(SearchCustomers), new FrameworkPropertyMetadata(new CheckOutHistory()));
        public CheckOutHistory COH
        {
            get { return (CheckOutHistory)GetValue(COHProperty); }
            set { SetValue(COHProperty, value); }
        }
        #endregion
        #region Customers
        public static readonly DependencyProperty CustomersProperty = DependencyProperty.Register("Customers", typeof(ObservableCollection<Customer>), typeof(SearchCustomers), new FrameworkPropertyMetadata(new ObservableCollection<Customer>()));
        public ObservableCollection<Customer> Customers
        {
            get { return (ObservableCollection<Customer>)GetValue(CustomersProperty); }
            set { SetValue(CustomersProperty, value); }
        }
        #endregion
        #region Filter
        public static readonly DependencyProperty FilterProperty = DependencyProperty.Register("Filter", typeof(string), typeof(SearchCustomers),
            new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(OnFilterChanged)));
        public string Filter
        {
            get { return (string)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }
        private static void OnFilterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SearchCustomers)d).OnFilterChanged(e);
        }
        protected virtual void OnFilterChanged(DependencyPropertyChangedEventArgs e)
        {
            dgCustomers.ItemsSource = new ObservableCollection<Customer>(Customers.Where(x => x.FullName != null && x.FullName.ToLower().Contains(Filter)));
        }
        #endregion
        #endregion
        #region Routed Commands
        #region CheckIn
        public static RoutedUICommand CheckIn = new RoutedUICommand("Check In", "CheckIn", typeof(SearchCustomers));
        private void CheckInExecuted(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void CanCheckIn(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        #endregion
        #region SellOut
        public static RoutedUICommand SellOut = new RoutedUICommand("Sell Out", "SellOut", typeof(SearchCustomers));
        private void SellOutExecuted(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void CanSellOut(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        #endregion
        #endregion
        public SearchCustomers()
        {
            InitializeComponent();
            txtSearchCriteria.txtContent.TextChanged += txtSearchCriteria_TextChanged;
        }
        #region Events
        private void DataGrid_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //DependencyObject depObj = (DependencyObject)e.OriginalSource;
            //while ((depObj != null) && !(depObj is DataGridRow))
            //    depObj = VisualTreeHelper.GetParent(depObj);
            //if (depObj == null)
            //    return;
            //var row = depObj as DataGridRow;
            //if (row == null)
            //    return;
            //var coh = row.DataContext as CheckOutHistory;
            //if (row.ContextMenu != null)
            //    row.ContextMenu.IsOpen = !(coh == null || !coh.IsCheckedOut);
        }
        private void dgCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCustomer = dgCustomers.SelectedItem as Customer;
            if (selectedCustomer != Globals.Default.SelectedCustomer)
                Globals.Default.SelectedCustomer = selectedCustomer;
        }
        private void searchCustomers_Loaded(object sender, RoutedEventArgs e)
        {
            txtSearchCriteria.Focus();
            Customers = new ObservableCollection<Customer>(Helpers.InventoryWindow.InventoryEntity.Customers);
        }
        private void txtSearchCriteria_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            Filter = textBox.Text.ToLower().Trim();
        }
        #endregion
        //private void RefreshCollectionView()
        //{
        //    CollectionViewSource cvs = (CollectionViewSource)FindResource("cvsInventory");
        //    cvs.View.Refresh();
        //}

        private void OnCheckInClick(object sender, RoutedEventArgs e)
        {
            COH.CheckInDate = DateTime.Now;
            Helpers.InventoryWindow.InventoryEntity.SaveChanges();
            //RefreshCollectionView();
            dgCustomers.Items.Refresh();
            e.Handled = true;
        }

        private void OnCheckOutHistorySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            COH = e.AddedItems[0] as CheckOutHistory;
        }
    }
}