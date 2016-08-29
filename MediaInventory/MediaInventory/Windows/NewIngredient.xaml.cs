using MediaInventory.Data;
using MediaInventory.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace MediaInventory.Windows
{
    public partial class NewIngredient : Window
    {
        #region Dependency Properties
        #region Filter
        public static readonly DependencyProperty FilterProperty = DependencyProperty.Register("Filter", typeof(string), typeof(NewIngredient),
            new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(OnFilterChanged)));
        public string Filter
        {
            get { return (string)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }
        private static void OnFilterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((NewIngredient)d).OnFilterChanged(e);
        }
        protected virtual void OnFilterChanged(DependencyPropertyChangedEventArgs e)
        {
            //dgIngredients.ItemsSource = new ObservableCollection<Ingredient>(Ingredients.Where(x => x.FullName != null && x.FullName.ToLower().Contains(Filter)));
            RefreshCollectionView();
        }
        #endregion
        #region SelectedIngredient
        public static readonly DependencyProperty SelectedIngredientProperty = DependencyProperty.Register("SelectedIngredient", typeof(Ingredient), typeof(NewIngredient), new FrameworkPropertyMetadata(null, OnSelectedIngredientChanged));
        public Ingredient SelectedIngredient
        {
            get { return (Ingredient)GetValue(SelectedIngredientProperty); }
            set { SetValue(SelectedIngredientProperty, value); }
        }
        private static void OnSelectedIngredientChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((NewIngredient)d).OnSelectedIngredientChanged(e);
        }
        protected virtual void OnSelectedIngredientChanged(DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion
        #endregion
        #region Routed Commands
        #region Cancel
        public static RoutedUICommand Cancel = new RoutedUICommand("Cancel", "Cancel", typeof(NewIngredient));
        private void CancelExecuted(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void CanCancel(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        #endregion
        #region Save
        public static RoutedUICommand Save = new RoutedUICommand("Save", "Save", typeof(NewIngredient));
        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void CanSave(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        #endregion
        #endregion
        public NewIngredient()
        {
            InitializeComponent();
        }
        #region Events
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void dgIngredients_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SelectedIngredient = dgIngredients.SelectedItem as Ingredient;
            if (SelectedIngredient != Globals.Default.SelectedIngredient)
                Globals.Default.SelectedIngredient = SelectedIngredient;
        }
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
        #endregion
        #region Methods
        public bool IngredientFilter(object item)
        {
            Ingredient Ingredient = item as Ingredient;
            return Ingredient != null && Ingredient.Name != null && Ingredient.Name.ToLower().Contains(Filter.ToLower());
        }
        private void RefreshCollectionView()
        {
            CollectionViewSource cvs = (CollectionViewSource)FindResource("cvsIngredients");
            cvs.View.Refresh();
        }
        #endregion
    }
}