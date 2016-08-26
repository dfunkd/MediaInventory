using MediaInventory.Data;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MediaInventory.UserControls
{
    public partial class AddRecipe : UserControl
    {
        public RadialGradientBrush ValuationFill = new RadialGradientBrush();
        private bool _isValidOrNullUrl = true;
        private bool _isValidRecipeName = false;
        #region Dependency Properties
        #region Items Needed To Save New Recipe
        #region NewRecipe
        public static readonly DependencyProperty NewRecipeProperty = DependencyProperty.Register("NewRecipe", typeof(Recipe), typeof(AddRecipe), new FrameworkPropertyMetadata(new Recipe(), FrameworkPropertyMetadataOptions.None,
            new PropertyChangedCallback(OnNewRecipeChanged)));
        public Recipe NewRecipe
        {
            get { return (Recipe)GetValue(NewRecipeProperty); }
            set { SetValue(NewRecipeProperty, value); }
        }
        private static void OnNewRecipeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AddRecipe)d).OnNewRecipeChanged(e);
        }
        protected virtual void OnNewRecipeChanged(DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion
        #region Quantity
        public static readonly DependencyProperty QuantityProperty = DependencyProperty.Register("Quantity", typeof(decimal?), typeof(AddRecipe), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None,
            new PropertyChangedCallback(OnQuantityChanged)));
        public decimal? Quantity
        {
            get { return (decimal?)GetValue(QuantityProperty); }
            set { SetValue(QuantityProperty, value); }
        }
        private static void OnQuantityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AddRecipe)d).OnQuantityChanged(e);
        }
        protected virtual void OnQuantityChanged(DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion
        #region RecipeIngredientList
        public static readonly DependencyProperty RecipeIngredientListProperty = DependencyProperty.Register("RecipeIngredientList", typeof(ObservableCollection<RecipeIngredient>), typeof(AddRecipe),
            new FrameworkPropertyMetadata(new ObservableCollection<RecipeIngredient>(), FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(OnRecipeIngredientListChanged)));
        public ObservableCollection<RecipeIngredient> RecipeIngredientList
        {
            get { return (ObservableCollection<RecipeIngredient>)GetValue(RecipeIngredientListProperty); }
            set { SetValue(RecipeIngredientListProperty, value); }
        }
        private static void OnRecipeIngredientListChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AddRecipe)d).OnRecipeIngredientListChanged(e);
        }
        protected virtual void OnRecipeIngredientListChanged(DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion
        #region RecipeIngredients
        public static readonly DependencyProperty RecipeIngredientsProperty = DependencyProperty.Register("RecipeIngredients", typeof(List<Ingredient>), typeof(AddRecipe), new FrameworkPropertyMetadata(new List<Ingredient>(),
            FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(OnRecipeIngredientsChanged)));
        public List<Ingredient> RecipeIngredients
        {
            get { return (List<Ingredient>)GetValue(RecipeIngredientsProperty); }
            set { SetValue(RecipeIngredientsProperty, value); }
        }
        private static void OnRecipeIngredientsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AddRecipe)d).OnRecipeIngredientsChanged(e);
        }
        protected virtual void OnRecipeIngredientsChanged(DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion
        #region RecipeImage
        public static readonly DependencyProperty RecipeImageProperty = DependencyProperty.Register("RecipeImage", typeof(BitmapImage), typeof(AddRecipe), new FrameworkPropertyMetadata(new BitmapImage()));
        public BitmapImage RecipeImage
        {
            get { return (BitmapImage)GetValue(RecipeImageProperty); }
            set { SetValue(RecipeImageProperty, value); }
        }
        #endregion
        #endregion
        #region IngredientList
        public static readonly DependencyProperty IngredientListProperty = DependencyProperty.Register("IngredientList", typeof(List<Ingredient>), typeof(AddRecipe), new FrameworkPropertyMetadata(new List<Ingredient>(),
            FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(OnIngredientListChanged)));
        public List<Ingredient> IngredientList
        {
            get { return (List<Ingredient>)GetValue(IngredientListProperty); }
            set { SetValue(IngredientListProperty, value); }
        }
        private static void OnIngredientListChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AddRecipe)d).OnIngredientListChanged(e);
        }
        protected virtual void OnIngredientListChanged(DependencyPropertyChangedEventArgs e)
        {
            cboIngredient.ItemsSource = null;
            cboIngredient.ItemsSource = IngredientList;
        }
        #endregion
        #region MeasurementList
        public static readonly DependencyProperty MeasurementListProperty = DependencyProperty.Register("MeasurementList", typeof(List<Measurement>), typeof(AddRecipe), new FrameworkPropertyMetadata(new List<Measurement>(),
            FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(OnMeasurementListChanged)));
        public List<Measurement> MeasurementList
        {
            get { return (List<Measurement>)GetValue(MeasurementListProperty); }
            set { SetValue(MeasurementListProperty, value); }
        }
        private static void OnMeasurementListChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AddRecipe)d).OnMeasurementListChanged(e);
        }
        protected virtual void OnMeasurementListChanged(DependencyPropertyChangedEventArgs e)
        {
            cboMeasurement.ItemsSource = null;
            cboMeasurement.ItemsSource = MeasurementList;
        }
        #endregion
        #region SelectedIngredient
        public static readonly DependencyProperty SelectedIngredientProperty = DependencyProperty.Register("SelectedIngredient", typeof(Ingredient), typeof(AddRecipe), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None,
            new PropertyChangedCallback(OnSelectedIngredientChanged)));
        public Ingredient SelectedIngredient
        {
            get { return (Ingredient)GetValue(SelectedIngredientProperty); }
            set { SetValue(SelectedIngredientProperty, value); }
        }
        private static void OnSelectedIngredientChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AddRecipe)d).OnSelectedIngredientChanged(e);
        }
        protected virtual void OnSelectedIngredientChanged(DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion
        #region SelectedMeasurement
        public static readonly DependencyProperty SelectedMeasurementProperty = DependencyProperty.Register("SelectedMeasurement", typeof(Measurement), typeof(AddRecipe), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None,
            new PropertyChangedCallback(OnSelectedMeasurementChanged)));
        public Measurement SelectedMeasurement
        {
            get { return (Measurement)GetValue(SelectedMeasurementProperty); }
            set { SetValue(SelectedMeasurementProperty, value); }
        }
        private static void OnSelectedMeasurementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AddRecipe)d).OnSelectedMeasurementChanged(e);
        }
        protected virtual void OnSelectedMeasurementChanged(DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion
        #endregion
        #region Routed Commands
        #region AddNewRecipe
        public static RoutedUICommand AddNewRecipe = new RoutedUICommand("Add Recipe", "AddRecipe", typeof(AddRecipe));
        private void AddNewRecipeExecuted(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void CanAddNewRecipe(object sender, CanExecuteRoutedEventArgs e)
        {
            //Image can be null
            //Valuation null means not tried, true means good, false means bad
            //URL can be null
            e.CanExecute = _isValidOrNullUrl && _isValidRecipeName;
        }
        #endregion
        #region AddRecipeIngredient
        public static RoutedUICommand AddRecipeIngredient = new RoutedUICommand("Add", "AddRecipeIngredient", typeof(AddRecipe));
        private void AddRecipeIngredientExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            RecipeIngredientList.Add(new RecipeIngredient(Quantity.Value, SelectedMeasurement, SelectedIngredient));
        }
        private void CanAddRecipeIngredient(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Quantity.HasValue && SelectedIngredient != null && SelectedMeasurement != null;
        }
        #endregion
        #region DeleteRecipeIngredient
        public static RoutedUICommand DeleteRecipeIngredient = new RoutedUICommand("Delete", "DeleteRecipeIngredient", typeof(AddRecipe));
        private void DeleteRecipeIngredientExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            RecipeIngredientList.Remove(dgRecipeIngredients.SelectedItem as RecipeIngredient);
        }
        private void CanDeleteRecipeIngredient(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = dgRecipeIngredients.Items.Count > 0;
        }
        #endregion
        #endregion
        public AddRecipe()
        {
            InitializeComponent();
            IngredientList = DataHelper.Default.Entity.Ingredients.ToList();
            MeasurementList = DataHelper.Default.Entity.Measurements.ToList();

            #region DemoData
            if (IngredientList.Count == 0)
            {
                IngredientList.Add(new Ingredient
                {
                    Id = 1,
                    Name = "Salt"
                });
                IngredientList.Add(
                new Ingredient
                {
                    Id = 2,
                    Name = "Pepper"
                });
            }
            if (MeasurementList.Count == 0)
            {
                MeasurementList.Add(new Measurement
                {
                    Abbreviation = "c",
                    Id = 1,
                    Name = "Cup"
                });
                MeasurementList.Add(new Measurement
                {
                    Abbreviation = "oz",
                    Id = 2,
                    Name = "Ounce"
                });
            }
            RecipeIngredientList.Add(new RecipeIngredient(decimal.Parse("1.5"), new Data.Measurement
            {
                Abbreviation = "c",
                Id = 1,
                Name = "Cup"
            }, new Data.Ingredient
            {
                Id = 1,
                Name = "Flour"
            }));
            RecipeIngredientList.Add(new RecipeIngredient(decimal.Parse("1.25"), new Data.Measurement
            {
                Abbreviation = "tsp",
                Id = 2,
                Name = "Teaspoon"
            }, new Data.Ingredient
            {
                Id = 2,
                Name = "Vanilla"
            }));
            #endregion DemoData

            Loaded += (s, e) =>
            {
                ChangeRecipeImage(@"/MediaInventory;component/Resources/Images/no_photo.jpg");
                imgRecipe.Source = RecipeImage;
                CalculateTotalTime();
                ValuationFill.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF6A5500"), 1));
                ValuationFill.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FFFFC500"), 0));
                ellValuation.Fill = ValuationFill;
            };
            txtSearchCriteria.txtContent.TextChanged += (s, e) =>
            {
                var searchCriteria = (e.Source as TextBox).Text;
                _isValidRecipeName = DataHelper.Default.Entity.Recipes.Where(w => w.Name.ToLower() == searchCriteria.ToLower()).FirstOrDefault() == null && !string.IsNullOrWhiteSpace(searchCriteria);
                if (!string.IsNullOrWhiteSpace(searchCriteria) && DataHelper.Default.Entity.Recipes.Where(w => w.Name == searchCriteria).FirstOrDefault() == null)
                    txtSearchCriteria.Background = ((Brush)(new BrushConverter()).ConvertFromString("#00FF0000"));
                else
                    txtSearchCriteria.Background = ((Brush)(new BrushConverter()).ConvertFromString("#FFFF0000"));
            };
            txtAquiredFromUrl.txtContent.TextChanged += (s, e) =>
            {
                var url = (e.Source as TextBox).Text;
                _isValidOrNullUrl = Regex.IsMatch(url, @"((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,15})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?")
                    || string.IsNullOrWhiteSpace(url);
                if (_isValidOrNullUrl)
                    txtAquiredFromUrl.Background = ((Brush)(new BrushConverter()).ConvertFromString("#00FF0000"));
                else
                    txtAquiredFromUrl.Background = ((Brush)(new BrushConverter()).ConvertFromString("#FFFF0000"));
            };
        }
        #region Events
        private void cboIngredient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedIngredient = (e.AddedItems.Count == 1 && e.AddedItems[0] is Ingredient) ? e.AddedItems[0] as Ingredient : null;
        }
        private void cboMeasurement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedMeasurement = (e.AddedItems.Count == 1 && e.AddedItems[0] is Measurement) ? e.AddedItems[0] as Measurement : null;
        }
        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ValuationFill.GradientOrigin = new Point(0.5, 0.8);
            ValuationFill.RadiusX = 0.6;
            ValuationFill.GradientStops.Clear();
            if (!NewRecipe.Valuation.HasValue)
            {
                NewRecipe.Valuation = true;
                //Green
                ValuationFill.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF005502"), 1));
                ValuationFill.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF15D600"), 0));
            }
            else if (NewRecipe.Valuation.Value == true)
            {
                NewRecipe.Valuation = false;
                //Red
                ValuationFill.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF6A0100"), 1));
                ValuationFill.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FFFF000C"), 0));
            }
            else
            {
                NewRecipe.Valuation = null;
                //Yellow
                ValuationFill.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF6A5500"), 1));
                ValuationFill.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FFFFC500"), 0));
            }
            ellValuation.Fill = ValuationFill;
        }
        private void OnImageClick(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                ChangeRecipeImage(filename);
                imgRecipe.Source = RecipeImage;
            }
        }
        private void OnTimeScaleChanged(object sender, RoutedEventArgs e)
        {
            CalculateTotalTime();
        }
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            CalculateTotalTime();
        }
        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal qty;
            Quantity = null;
            if (decimal.TryParse(txtQuantity.Text, out qty))
                Quantity = qty;
        }
        #endregion
        #region Private Methods
        private void CalculateTotalTime()
        {
            int prepTime, cookTime;
            if (!int.TryParse(txtPrepTime.Text, out prepTime))
                prepTime = 0;
            if (!int.TryParse(txtCookTime.Text, out cookTime))
                cookTime = 0;
            if (rdoPrepHours.IsChecked.Value)
                prepTime = prepTime * 60;
            if (rdoCookHours.IsChecked.Value)
                cookTime = cookTime * 60;
            var totalTime = prepTime + cookTime;
            var ts = TimeSpan.FromMinutes(totalTime);
            string dayString = string.Empty, hourString = string.Empty, minuteString = string.Empty;
            if (ts.Days > 0)
                dayString = ts.Days > 1 ? " Days" : " Day";
            if (ts.Hours > 0)
                hourString = ts.Minutes > 1 ? " Hours" : " Hour";
            if (ts.Minutes > 0)
                minuteString = ts.Minutes > 1 ? " Minutes" : " Minute";
            string daysHoursMinutes;
            if (!string.IsNullOrWhiteSpace(dayString))
                daysHoursMinutes = string.Format("{0} {1}, {2} {3}, {4} {5}", ts.Days, dayString, ts.Hours, hourString, ts.Minutes, minuteString);
            else if (!string.IsNullOrWhiteSpace(hourString))
                daysHoursMinutes = string.Format("{0} {1}, {2} {3}", ts.Hours, hourString, ts.Minutes, minuteString);
            else if (!string.IsNullOrWhiteSpace(minuteString))
                daysHoursMinutes = string.Format("{0} {1}", ts.Minutes, minuteString);
            else
                daysHoursMinutes = "N/A";
            tbTotalTime.Text = daysHoursMinutes;
        }
        private void ChangeRecipeImage(string fileLocation)
        {
            RecipeImage = new BitmapImage();
            RecipeImage.BeginInit();
            RecipeImage.UriSource = new Uri(fileLocation, UriKind.RelativeOrAbsolute);
            RecipeImage.EndInit();
        }
        #endregion
    }
}