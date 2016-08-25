using MediaInventory.Data;
using MediaInventory.Resources;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaInventory.UserControls
{
    public partial class SearchRecipes : UserControl
    {
        public CollectionViewSource Recipes { get; set; }
        private ObservableCollection<Movie> RecipesInternal { get; set; }
        #region Dependency Properties
        #region Filter
        public static readonly DependencyProperty FilterProperty = DependencyProperty.Register("Filter", typeof(string), typeof(SearchRecipes),
            new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(OnFilterChanged)));
        public string Filter
        {
            get { return (string)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }
        private static void OnFilterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SearchRecipes)d).OnFilterChanged(e);
        }
        protected virtual void OnFilterChanged(DependencyPropertyChangedEventArgs e)
        {
            RefreshCollectionView();
        }
        #endregion
        #endregion
        #region Routed Commands
        #region ChangeValuation
        public static RoutedUICommand ChangeValuation = new RoutedUICommand("Change Valuation", "ChangeValuation", typeof(SearchRecipes));
        private void ChangeValuationExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var recipe = dgRecipes.SelectedItem as Recipe;
            if ((e.Source as RadioButton) != null && (e.Source as RadioButton).IsChecked == true)
            {
                if (Globals.Default.SelectedRecipe.Valuation == null)
                    recipe.Valuation = true;
                else if (Globals.Default.SelectedRecipe.Valuation == true)
                    recipe.Valuation = false;
                else
                    recipe.Valuation = null;
                Helpers.InventoryWindow.InventoryEntity.SaveChanges();
                RefreshCollectionView();
            }
        }
        private void CanChangeValuation(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        #endregion
        #endregion
        public SearchRecipes()
        {
            InitializeComponent();
            Globals.Default.PropertyChanged += Globals_PropertyChanged;
            txtSearchCriteria.txtContent.TextChanged += txtSearchCriteria_TextChanged;
            RefreshCollectionViewSource();
        }
        #region Events
        private void dgRecipes_GotFocus(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource.GetType() == typeof(DataGridCell))
            {
                DataGrid grd = (DataGrid)sender;
                grd.BeginEdit(e);
                Control control = Helpers.GetFirstChildByType<Control>(e.OriginalSource as DataGridCell);
                if (control != null)
                    control.Focus();
            }
        }
        private void dgRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRecipe = dgRecipes.SelectedItem as Recipe;
            if (selectedRecipe != Globals.Default.SelectedRecipe)
                Globals.Default.SelectedRecipe = selectedRecipe;
        }
        private void Globals_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "RecipeGroupHeaderType":
                    dgRecipes.SelectedIndex = -1;
                    break;
            }
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
        private void OnExpandClick(object sender, RoutedEventArgs e)
        {
            if (!(sender is RadioButton))
                return;
            var rad = sender as RadioButton;
            if (!(rad.Content is DockPanel))
                return;
            var dp = rad.Content as DockPanel;
            var path = dp.Children.OfType<Path>().Where(w => w.Name == "path").FirstOrDefault();
            if (path == null || path.Data == null)
                return;
            path.Data = (path.Data.ToString() == "M0,6L12,6 6,0z") ? Geometry.Parse("M0,0L6,6 12,0z") : Geometry.Parse("M0,6L12,6 6,0z");
        }
        private void OnSelectRowDetails(object sender, MouseButtonEventArgs e)
        {
            Helpers.SelectRowDetails(sender);
        }
        private void rdoChangeValuation_Click(object sender, RoutedEventArgs e)
        {
            var recipe = dgRecipes.SelectedItem as Recipe;
            if ((e.Source as RadioButton) != null && (e.Source as RadioButton).IsChecked == true)
            {
                if (Globals.Default.SelectedRecipe.Valuation == null)
                    recipe.Valuation = true;
                else if (Globals.Default.SelectedRecipe.Valuation == true)
                    recipe.Valuation = false;
                else
                    recipe.Valuation = null;
                Helpers.InventoryWindow.InventoryEntity.SaveChanges();
                RefreshCollectionView();
            }
        }
        private void searchRecipes_Loaded(object sender, RoutedEventArgs e)
        {
            txtSearchCriteria.Focus();
            CollectionViewSource cvs = (CollectionViewSource)FindResource("cvsRecipes");
            cvs.Source = new ObservableCollection<Recipe>(Helpers.InventoryWindow.InventoryEntity.Recipes.OrderBy(o => o.Name));
            cvs.View.Filter = RecipeFilter;
            dgRecipes.ItemsSource = cvs.View;
            dgRecipes.SelectedIndex = 0;
        }
        private void txtSearchCriteria_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            Filter = textBox.Text.ToLower().Trim();
        }
        #endregion
        #region Public Methods
        public bool RecipeFilter(object item)
        {
            Recipe movie = item as Recipe;
            return movie != null && movie.Name != null && movie.Name.ToLower().Contains(Filter.ToLower());
        }
        public void RefreshCollectionView()
        {
            CollectionViewSource cvs = (CollectionViewSource)FindResource("cvsRecipe");
            if (cvs != null && cvs.View != null)
                cvs.View.Refresh();
        }
        public void RefreshCollectionViewSource()
        {
            RecipesInternal = new ObservableCollection<Movie>();
            Recipes = new CollectionViewSource();
            Recipes.Source = RecipesInternal;
            Recipes.View.Filter = RecipeFilter;
            Recipes.SortDescriptions.Clear();
            Recipes.View.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            foreach (var movie in Helpers.InventoryWindow.InventoryEntity.Movies)
                RecipesInternal.Add(movie);
            dgRecipes.ItemsSource = Recipes.View;
            dgRecipes.SelectedIndex = 0;
        }
        #endregion
    }
}
