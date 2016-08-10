using MediaInventory.Properties;
using System.Windows;
using System.Windows.Controls;

namespace MediaInventory.UserControls
{
    public partial class InventorySettings : UserControl
    {
        #region Dependency Properties
        #region IsChanged
        public static readonly DependencyProperty IsChangedProperty = DependencyProperty.Register("IsChanged", typeof(bool), typeof(InventorySettings), new FrameworkPropertyMetadata(false));
        public bool IsChanged
        {
            get { return (bool)GetValue(IsChangedProperty); }
            set { SetValue(IsChangedProperty, value); }
        }
        #endregion
        #region TimeoutPeriod
        public static readonly DependencyProperty TimeoutPeriodProperty = DependencyProperty.Register("TimeoutPeriod",
          typeof(int), typeof(InventorySettings), new FrameworkPropertyMetadata(300, OnTimeoutPeriodChanged));
        public int TimeoutPeriod
        {
            get { return (int)GetValue(TimeoutPeriodProperty); }
            set { SetValue(TimeoutPeriodProperty, value); }
        }
        private static void OnTimeoutPeriodChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((InventorySettings)d).OnTimeoutPeriodChanged(e);
        }
        protected virtual void OnTimeoutPeriodChanged(DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion
        #endregion
        #region Routed Commands

        #endregion
        public InventorySettings()
        {
            InitializeComponent();
        }
        private void SaveSettings()
        {
            Settings.Default.Save();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.TimeoutPeriod != TimeoutPeriod)
            {
                Settings.Default.TimeoutPeriod = TimeoutPeriod;
                SaveSettings();
            }
        }
    }
}