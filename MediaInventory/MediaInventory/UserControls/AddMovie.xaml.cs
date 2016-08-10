using MediaInventory.Data;
using MediaInventory.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace MediaInventory.UserControls
{
    public partial class AddMovie : UserControl
    {
        #region Dependency Properties
        #region NewMovie
        public static readonly DependencyProperty NewMovieProperty = DependencyProperty.Register("NewMovie", typeof(Movie), typeof(AddMovie), new FrameworkPropertyMetadata(null));
        public Movie NewMovie
        {
            get { return (Movie)GetValue(NewMovieProperty); }
            set { SetValue(NewMovieProperty, value); }
        }
        #endregion
        #region PageCount
        public static readonly DependencyProperty PageCountProperty = DependencyProperty.Register("PageCount", typeof(int), typeof(AddMovie), new FrameworkPropertyMetadata(1, OnPageCountChanged));
        public int PageCount
        {
            get { return (int)GetValue(PageCountProperty); }
            set { SetValue(PageCountProperty, value); }
        }
        private static void OnPageCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AddMovie)d).OnPageCountChanged(e);
        }
        protected virtual void OnPageCountChanged(DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion
        #region PageLocation
        public static readonly DependencyProperty PageLocationProperty = DependencyProperty.Register("PageLocation", typeof(string), typeof(AddMovie), new FrameworkPropertyMetadata(string.Empty, OnPageLocationChanged));
        public string PageLocation
        {
            get { return (string)GetValue(PageLocationProperty); }
            set { SetValue(PageLocationProperty, value); }
        }
        private static void OnPageLocationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AddMovie)d).OnPageLocationChanged(e);
        }
        protected virtual void OnPageLocationChanged(DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion
        #region PageNumber
        public static readonly DependencyProperty PageNumberProperty = DependencyProperty.Register("PageNumber", typeof(int), typeof(AddMovie), new FrameworkPropertyMetadata(1, OnPageNumberChanged));
        public int PageNumber
        {
            get { return (int)GetValue(PageNumberProperty); }
            set { SetValue(PageNumberProperty, value); }
        }
        private static void OnPageNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AddMovie)d).OnPageNumberChanged(e);
        }
        protected virtual void OnPageNumberChanged(DependencyPropertyChangedEventArgs e)
        {
            //PopulatePosters();
        }
        #endregion
        #region Posters
        public static readonly DependencyProperty PostersProperty = DependencyProperty.Register("Posters", typeof(Dictionary<int, string>), typeof(AddMovie), new FrameworkPropertyMetadata(new Dictionary<int, string>(), FrameworkPropertyMetadataOptions.None));
        public Dictionary<int, string> Posters
        {
            get { return (Dictionary<int, string>)GetValue(PostersProperty); }
            set { SetValue(PostersProperty, value); }
        }
        #endregion
        #region SearchContainer
        public static readonly DependencyProperty SearchContainerProperty = DependencyProperty.Register("SearchContainer", typeof(TMDbLib.Objects.General.SearchContainer<TMDbLib.Objects.Search.SearchMovie>), typeof(AddMovie),
            new FrameworkPropertyMetadata(new TMDbLib.Objects.General.SearchContainer<TMDbLib.Objects.Search.SearchMovie>()));
        public TMDbLib.Objects.General.SearchContainer<TMDbLib.Objects.Search.SearchMovie> SearchContainer
        {
            get { return (TMDbLib.Objects.General.SearchContainer<TMDbLib.Objects.Search.SearchMovie>)GetValue(SearchContainerProperty); }
            set { SetValue(SearchContainerProperty, value); }
        }
        #endregion
        #endregion
        #region Routed Commands
        #region AddMovieCommand
        public static RoutedUICommand AddMovieCommand = new RoutedUICommand("Add Movie", "AddMovieCommand", typeof(AddMovie));
        private void AddMovieCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            //Remove after Format Selection is Setup.
            NewMovie.FORId = 2;
            if (Helpers.InventoryWindow.InventoryEntity.Movies.ToList().FindAll(f => f.Name == NewMovie.Name && f.FORId == NewMovie.FORId).Count == 0)
            {
                Helpers.InventoryWindow.InventoryEntity.Movies.Add(NewMovie);
                Helpers.InventoryWindow.InventoryEntity.SaveChanges();
                Helpers.InventoryWindow.InventoryEntity.CheckOutHistories.Add(new CheckOutHistory
                {
                    CheckInDate = null,
                    CheckOutDate = DateTime.Now,
                    CSTid = 1,
                    MOVid = NewMovie.Id
                });
                Helpers.InventoryWindow.InventoryEntity.SaveChanges();
                txtSearchCriteria.txtContent.Text = string.Empty;
            }
            else
                MessageBox.Show("Movie / Format combination is already in the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
        private void CanAddMovieCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = NewMovie != null;
        }
        #endregion
        #region FirstPage
        public static RoutedUICommand FirstPage = new RoutedUICommand("First Page", "FirstPage", typeof(AddMovie));
        private void FirstPageExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            PageNumber = 1;
            PopulatePosters();
        }
        private void CanFirstPage(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = PageCount > 1;
        }
        #endregion
        #region OwnedWantedClick
        public static RoutedUICommand OwnedWantedClick = new RoutedUICommand("OwnedWanted", "OwnedWantedClick", typeof(AddMovie));
        private void OwnedWantedClickExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (!NewMovie.IsOwned && !NewMovie.IsWanted)
            {
                NewMovie.IsWanted = true;
                tbtIsOwnedWanted.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFB2B365");
                tbtIsOwnedWanted.Content = "Wanted";
            }
            else if (!NewMovie.IsOwned && NewMovie.IsWanted)
            {
                NewMovie.IsOwned = true;
                tbtIsOwnedWanted.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF5CA461");
                tbtIsOwnedWanted.Content = "Owned";
            }
            else
            {
                NewMovie.IsOwned = false;
                NewMovie.IsWanted = false;
                tbtIsOwnedWanted.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFB46765");
                tbtIsOwnedWanted.Content = "Not Owned";
            }
            e.Handled = true;
        }
        private void CanOwnedWantedClick(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        #endregion
        #region LastPage
        public static RoutedUICommand LastPage = new RoutedUICommand("Last Page", "LastPage", typeof(AddMovie));
        private void LastPageExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            PageNumber = SearchContainer.TotalPages;
            PopulatePosters(PageNumber);
        }
        private void CanLastPage(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = PageCount > 1;
        }
        #endregion
        #region NextPage
        public static RoutedUICommand NextPage = new RoutedUICommand("Next Page", "NextPage", typeof(AddMovie));
        private void NextPageExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            PageNumber++;
            PopulatePosters(PageNumber);
        }
        private void CanNextPage(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = PageNumber != SearchContainer.TotalPages;
        }
        #endregion
        #region PreviousPage
        public static RoutedUICommand PreviousPage = new RoutedUICommand("Previous Page", "PreviousPage", typeof(AddMovie));
        private void PreviousPageExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            PageNumber--;
            PopulatePosters(PageNumber);
        }
        private void CanPreviousPage(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = PageNumber > 1;
        }
        #endregion
        #endregion
        public AddMovie()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                dpMovieInfo.Visibility = Visibility.Collapsed;
                lbMovies.SelectedIndex = -1;
            };
            txtSearchCriteria.txtContent.TextChanged += (s, e) =>
            {
                PopulatePosters();
            };
        }
        private void PopulatePosters(int pageNumber = 1)
        {
            if (pageNumber == 1)
            {
                PageNumber = pageNumber;
                SearchContainer = App.Client.SearchMovie(txtSearchCriteria.txtContent.Text);
            }
            else
                SearchContainer = App.Client.SearchMovie(txtSearchCriteria.txtContent.Text, pageNumber);
            Posters = new Dictionary<int, string>();            
            if (SearchContainer.Results != null)
                foreach (var item in SearchContainer.Results)
                    Posters.Add(item.Id, string.IsNullOrWhiteSpace(item.PosterPath) ? string.Empty : App.Client.GetImageUrl("original", item.PosterPath).AbsoluteUri);
            PageCount = SearchContainer.TotalPages;
            PageLocation = string.Format("{0} of {1}", PageNumber, PageCount);
            dpPageNav.Visibility = SearchContainer.TotalPages > 1 ? Visibility.Visible : Visibility.Hidden;
            CollectionViewSource cvs = (CollectionViewSource)FindResource("cvsMovies");
            cvs.Source = Posters;
            cvs.View.Refresh();
        }
        private void lbMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var item = (KeyValuePair<int, string>)e.AddedItems[0];
                var movie = App.Client.GetMovie(item.Key);
                if (movie != null)
                {
                    dpMovieInfo.Visibility = Visibility.Visible;
                    NewMovie = new Movie(movie);
                    NewMovie.IsOwned = false;
                    NewMovie.IsWanted = false;
                    tbtIsOwnedWanted.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFB46765");
                    tbtIsOwnedWanted.Content = "Not Owned";
                }
                else
                    dpMovieInfo.Visibility = Visibility.Collapsed;
            }
        }
    }
}