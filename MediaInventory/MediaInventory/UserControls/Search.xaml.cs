using MediaInventory.Data;
using MediaInventory.Resources;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MediaInventory.UserControls
{
    public partial class Search : UserControl
    {
        #region Dependency Properties
        #region InventoryType
        public static readonly DependencyProperty InventoryTypeProperty = DependencyProperty.Register("InventoryType", typeof(InventoryTypes), typeof(Search),
            new FrameworkPropertyMetadata(Globals.Default.InventoryType, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(OnInventoryTypeChanged)));
        public InventoryTypes InventoryType
        {
            get { return (InventoryTypes)GetValue(InventoryTypeProperty); }
            set { SetValue(InventoryTypeProperty, value); }
        }
        private static void OnInventoryTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Search)d).OnInventoryTypeChanged(e);
        }
        protected virtual void OnInventoryTypeChanged(DependencyPropertyChangedEventArgs e)
        {
            Globals.Default.InventoryType = InventoryType;
            switch (InventoryType)
            {
                case InventoryTypes.Books:
                    break;
                case InventoryTypes.Customers:
                    
                    break;
                case InventoryTypes.Movies:
                    searchMovies.RefreshCollectionView();
                    break;
                case InventoryTypes.Music:
                    break;
                default:
                    break;
            }
        }
        #endregion
        #region ItemsSource
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(Search), new FrameworkPropertyMetadata(null));
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        #endregion
        #endregion
        public Search()
        {
            InitializeComponent();
            //CollectionViewSource cvs = (CollectionViewSource)(Parent as Inventory).FindResource("cvsInventory");
        }
    }
}