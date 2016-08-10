using MediaInventory.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MediaInventory.Windows
{
    public partial class ViewCheckOutHistoryWindow : Window
    {
        #region Dependency Properties
        #region CheckOutHistory
        public static readonly DependencyProperty CheckOutHistoryProperty = DependencyProperty.Register("CheckOutHistory",
          typeof(List<Data.CheckOutHistory>), typeof(ViewCheckOutHistoryWindow), new FrameworkPropertyMetadata(new List<Data.CheckOutHistory>(), OnCheckOutHistoryChanged));
        public List<Data.CheckOutHistory> CheckOutHistory
        {
            get { return (List<Data.CheckOutHistory>)GetValue(CheckOutHistoryProperty); }
            set { SetValue(CheckOutHistoryProperty, value); }
        }
        private static void OnCheckOutHistoryChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ViewCheckOutHistoryWindow)d).OnCheckOutHistoryChanged(e);
        }
        protected virtual void OnCheckOutHistoryChanged(DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion
        #region Header
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(ViewCheckOutHistoryWindow), new FrameworkPropertyMetadata(string.Empty, OnHeaderChanged));
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
        private static void OnHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ViewCheckOutHistoryWindow)d).OnHeaderChanged(e);
        }
        protected virtual void OnHeaderChanged(DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion
        #endregion
        #region Routed Commands
        #region CloseWindow
        public static RoutedUICommand CloseWindow = new RoutedUICommand("Close", "CloseWindow", typeof(ViewCheckOutHistoryWindow));
        private void CloseWindowExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
        private void CanCloseWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        #endregion
        #endregion
        #region Constructors
        public ViewCheckOutHistoryWindow()
        {
            InitializeComponent();
            Header = Globals.Default.SelectedMovie.Name;
        }
        #endregion
        #region Events
        private void checkoutHistory_Loaded(object sender, RoutedEventArgs e)
        {
            CheckOutHistory = Globals.Default.SelectedMovie.CheckOutHistories.ToList();
        }
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        #endregion
    }
}