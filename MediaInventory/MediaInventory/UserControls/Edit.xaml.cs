using MediaInventory.Resources;
using System.Windows;
using System.Windows.Controls;

namespace MediaInventory.UserControls
{
    public partial class Edit : UserControl
    {
        #region Dependency Properties
        #region InventoryType
        public static readonly DependencyProperty InventoryTypeProperty = DependencyProperty.Register("InventoryType", typeof(InventoryTypes), typeof(Edit),
            new FrameworkPropertyMetadata(InventoryTypes.None, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(OnInventoryTypeChanged)));
        public InventoryTypes InventoryType
        {
            get { return (InventoryTypes)GetValue(InventoryTypeProperty); }
            set { SetValue(InventoryTypeProperty, value); }
        }
        private static void OnInventoryTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Edit)d).OnInventoryTypeChanged(e);
        }
        protected virtual void OnInventoryTypeChanged(DependencyPropertyChangedEventArgs e)
        {
            Globals.Default.InventoryType = InventoryType;
        }
        #endregion
        #endregion
        public Edit()
        {
            InitializeComponent();
        }
    }
}