using MediaInventory.Data;
using MediaInventory.Resources;
using MediaInventory.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TMDbLib.Objects.TvShows;

namespace MediaInventory.UserControls
{
    public partial class SearchMovies : UserControl
    {
        public CollectionViewSource Movies { get; set; }
        private ObservableCollection<Movie> MoviesInternal { get; set; }
        #region Private Properties
        private bool checkoutCancelled = false;
        //private ListCollectionView collection;
        #endregion
        #region Dependency Properties
        #region Filter
        public static readonly DependencyProperty FilterProperty = DependencyProperty.Register("Filter", typeof(string), typeof(SearchMovies),
            new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(OnFilterChanged)));
        public string Filter
        {
            get { return (string)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }
        private static void OnFilterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SearchMovies)d).OnFilterChanged(e);
        }
        protected virtual void OnFilterChanged(DependencyPropertyChangedEventArgs e)
        {
            RefreshCollectionView();
        }
        #endregion
        #region TvShows
        public static readonly DependencyProperty TvShowsProperty = DependencyProperty.Register("TvShows", typeof(ObservableCollection<TvSeason>), typeof(SearchMovies),
            new FrameworkPropertyMetadata(new ObservableCollection<TvSeason>()));
        public ObservableCollection<TvSeason> TvShows
        {
            get { return (ObservableCollection<TvSeason>)GetValue(TvShowsProperty); }
            set { SetValue(TvShowsProperty, value); }
        }
        #endregion
        #region SelectedTvShow
        public static readonly DependencyProperty SelectedTvShowProperty = DependencyProperty.Register("SelectedTvShow", typeof(TvShow), typeof(SearchMovies),
            new FrameworkPropertyMetadata(null, OnSelectedTvShowChanged));
        public TvShow SelectedTvShow
        {
            get { return (TvShow)GetValue(SelectedTvShowProperty); }
            set { SetValue(SelectedTvShowProperty, value); }
        }
        private static void OnSelectedTvShowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SearchMovies)d).OnSelectedTvShowChanged(e);
        }
        protected virtual void OnSelectedTvShowChanged(DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion
        #endregion
        #region Routed Commands
        #region OwnedWantedClick
        public static RoutedUICommand OwnedWantedClick = new RoutedUICommand("OwnedWanted", "OwnedWantedClick", typeof(SearchMovies));
        private void OwnedWantedClickExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var movie = dgMovies.SelectedItem as Movie;
            if (!movie.IsOwned && !movie.IsWanted)
                movie.IsWanted = true;
            else if (!movie.IsOwned && movie.IsWanted)
                movie.IsOwned = true;
            else
            {
                movie.IsOwned = false;
                movie.IsWanted = false;
            }
            Helpers.InventoryWindow.InventoryEntity.SaveChanges();
            RefreshCollectionView();
            e.Handled = true;
        }
        private void CanOwnedWantedClick(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Globals.Default.SelectedMovie != null;
        }
        #endregion
        #region ViewCheckOutHistory
        public static RoutedUICommand ViewCheckOutHistory = new RoutedUICommand("View Check Out History", "ViewCheckOutHistory", typeof(SearchMovies));
        private void ViewCheckOutHistoryExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var view = new ViewCheckOutHistoryWindow();
            view.Owner = Application.Current.MainWindow;
            view.ShowDialog();
        }
        private void CanViewCheckOutHistory(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Globals.Default.SelectedMovie != null && Globals.Default.SelectedMovie.CheckOutHistories.Count > 0;
        }
        #endregion
        #endregion
        #region Constructors
        public SearchMovies()
        {
            InitializeComponent();
            Globals.Default.PropertyChanged += Globals_PropertyChanged;
            txtSearchCriteria.txtContent.TextChanged += txtSearchCriteria_TextChanged;
            RefreshCollectionViewSource();
        }
        #endregion
        #region Events
        private void cboIsOwned_Checked(object sender, RoutedEventArgs e)
        {
            var movie = dgMovies.SelectedItem as Movie;
            movie.IsOwned = true;
            if (movie.IsWanted)
                movie.IsWanted = false;
            Helpers.InventoryWindow.InventoryEntity.SaveChanges();
            RefreshCollectionView();
            e.Handled = true;
        }
        private void cboIsOwned_Unchecked(object sender, RoutedEventArgs e)
        {
            var movie = dgMovies.SelectedItem as Movie;
            movie.IsOwned = false;
            if (movie.IsWanted)
                movie.IsWanted = true;
            Helpers.InventoryWindow.InventoryEntity.SaveChanges();
            RefreshCollectionView();
            e.Handled = true;
        }
        private void cboIsWanted_Checked(object sender, RoutedEventArgs e)
        {
            var movie = dgMovies.SelectedItem as Movie;
            movie.IsWanted = true;
            if (movie.IsOwned)
                movie.IsOwned = false;
            Helpers.InventoryWindow.InventoryEntity.SaveChanges();
            RefreshCollectionView();
            e.Handled = true;
        }
        private void cboIsWanted_Unchecked(object sender, RoutedEventArgs e)
        {
            var movie = dgMovies.SelectedItem as Movie;
            movie.IsWanted = false;
            Helpers.InventoryWindow.InventoryEntity.SaveChanges();
            RefreshCollectionView();
            e.Handled = true;
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
        //Focus individual data grid cells
        private void dgMovies_GotFocus(object sender, RoutedEventArgs e)
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
        private void dgMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedMovie = dgMovies.SelectedItem as Movie;
            if (selectedMovie != Globals.Default.SelectedMovie)
                Globals.Default.SelectedMovie = selectedMovie;
        }
        private void dgTvShows_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //SelectedTvShow = dgTvShows.SelectedItem as TvShow;
            //var test = Client.GetTvShowImages(SelectedTvShow.Id, "en");
        }
        private void Globals_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedMovie":
                    if (Globals.Default.SelectedMovie != null)
                        Helpers.PopulateTMDbData(Globals.Default.SelectedMovie);
                    break;
                case "MovieGroupHeaderType":
                    dgMovies.SelectedIndex = -1;
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
        private void OnGroupByChanged(object sender, RoutedEventArgs e)
        {
            ((CollectionViewSource)FindResource("cvsInventory")).GroupDescriptions.Clear();
            if (rdoFormat.IsChecked == true)
            {
                Globals.Default.MovieGroupHeaderType = MovieGroupHeaderTypes.Format;
                ((CollectionViewSource)FindResource("cvsInventory")).GroupDescriptions.Add(new PropertyGroupDescription("Format"));
            }
            else if (rdoStatus.IsChecked == true)
            {
                Globals.Default.MovieGroupHeaderType = MovieGroupHeaderTypes.CheckStatus;
                ((CollectionViewSource)FindResource("cvsInventory")).GroupDescriptions.Add(new PropertyGroupDescription("IsCheckedOut"));
            }
            else if (rdoOwned.IsChecked == true)
            {
                Globals.Default.MovieGroupHeaderType = MovieGroupHeaderTypes.Owned;
                ((CollectionViewSource)FindResource("cvsInventory")).GroupDescriptions.Add(new PropertyGroupDescription("IsOwned"));
            }
            else if (rdoWanted.IsChecked == true)
            {
                Globals.Default.MovieGroupHeaderType = MovieGroupHeaderTypes.Wanted;
                ((CollectionViewSource)FindResource("cvsInventory")).GroupDescriptions.Add(new PropertyGroupDescription("IsWanted"));
            }
        }
        //Focus Row Details
        private void OnSelectRowDetails(object sender, MouseButtonEventArgs e)
        {
            Helpers.SelectRowDetails(sender);
        }
        private void rdoIsCheckedOut_Click(object sender, RoutedEventArgs e)
        {
            var movie = dgMovies.SelectedItem as Movie;
            if ((e.Source as RadioButton) != null && (e.Source as RadioButton).IsChecked == true)
            {
                var customerWindow = new CheckOutToCustomer();
                customerWindow.Owner = Application.Current.MainWindow;
                var result = customerWindow.ShowDialog();
                if (!result.HasValue || result == false)
                {
                    e.Handled = true;
                    checkoutCancelled = true;
                    (sender as RadioButton).IsChecked = false;
                }
                else
                {
                    (sender as RadioButton).IsChecked = true;
                    movie.CheckOutHistories.Add(new CheckOutHistory
                    {
                        CheckInDate = null,
                        CheckOutDate = DateTime.Now,
                        CSTid = Globals.Default.SelectedCustomer.Id,
                        MOVid = movie.Id
                    });
                    Helpers.InventoryWindow.InventoryEntity.SaveChanges();
                    RefreshCollectionView();
                    e.Handled = true;
                }
            }
            else
            {
                if (checkoutCancelled)
                {
                    checkoutCancelled = false;
                    return;
                }
                if (Globals.Default.SelectedMovie == null)
                {
                    e.Handled = false;
                    return;
                }
                var coh = movie.CheckOutHistories.Where(w => w.MOVid == Globals.Default.SelectedMovie.Id && w.CheckInDate == null).FirstOrDefault();
                if (coh == null)
                {
                    e.Handled = false;
                    return;
                }
                coh.CheckInDate = DateTime.Now;
                Helpers.InventoryWindow.InventoryEntity.SaveChanges();
                RefreshCollectionView();
            }
        }
        private void searchMovies_Loaded(object sender, RoutedEventArgs e)
        {
            txtSearchCriteria.Focus();
            CollectionViewSource cvs = (CollectionViewSource)FindResource("cvsInventory");
            cvs.Source = new ObservableCollection<Movie>(Helpers.InventoryWindow.InventoryEntity.Movies);
            cvs.View.Filter = MovieFilter;
            dgMovies.ItemsSource = cvs.View;
            dgMovies.SelectedIndex = 0;
        }
        public void RefreshCollectionViewSource()
        {
            MoviesInternal = new ObservableCollection<Movie>();
            Movies = new CollectionViewSource();
            Movies.Source = MoviesInternal;
            Movies.View.Filter = MovieFilter;
            Movies.SortDescriptions.Clear();
            Movies.View.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            foreach (var movie in Helpers.InventoryWindow.InventoryEntity.Movies)
                MoviesInternal.Add(movie);
            dgMovies.ItemsSource = Movies.View;
            dgMovies.SelectedIndex = 0;
        }
        public bool MovieFilter(object item)
        {
            Movie movie = item as Movie;
            return movie != null && (movie.Name != null && movie.Name.ToLower().Contains(Filter.ToLower())) || (movie.Title != null && movie.Title.ToLower().Contains(Filter.ToLower()));
        }
        
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var tb = (sender as ToggleButton);
            if (tb == null)
                return;
            if (Globals.Default.SelectedMovie == null)
            {
                e.Handled = false;
                return;
            }
            var movie = Helpers.InventoryWindow.InventoryEntity.Movies.Where(w => w.Id == Globals.Default.SelectedMovie.Id).SingleOrDefault();
            if (movie == null)
            {
                e.Handled = false;
                return;
            }
            if (tb.IsChecked == null)//Neither Owned nor Wanted
            {
                tb.Content = "Not Owned";
                tb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF9A4D4C"));
                movie.IsOwned = false;
                movie.IsWanted = false;
            }
            else if (tb.IsChecked == true)//Owned
            {
                tb.Content = "Owned";
                movie.IsOwned = true;
                movie.IsWanted = false;
                tb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF44608A"));
            }
            else//Wanted
            {
                tb.Content = "Wanted";
                movie.IsOwned = false;
                movie.IsWanted = true;
                tb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFC48988"));
            }
            Helpers.InventoryWindow.InventoryEntity.SaveChanges();
            RefreshCollectionView();
            e.Handled = true;
        }
        private void txtSearchCriteria_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            Filter = textBox.Text.ToLower().Trim();
        }
        #endregion
        #region Methods
        public void RefreshCollectionView()
        {
            CollectionViewSource cvs = (CollectionViewSource)FindResource("cvsInventory");
            if (cvs != null && cvs.View != null)
                cvs.View.Refresh();
        }
        #endregion
    }
}