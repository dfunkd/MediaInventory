using MediaInventory.Data;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MediaInventory.UserControls
{
    public partial class AddRecipe : UserControl
    {
        #region Dependency Properties
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
        public AddRecipe()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                ChangeRecipeImage(@"/MediaInventory;component/Resources/Images/no_photo.jpg");
                imgRecipe.Source = RecipeImage;
            };
            txtSearchCriteria.txtContent.TextChanged += (s, e) =>
            {
                var searchCriteria = e.Source.ToString();
                if (DataHelper.Default.Entity.Recipes.Where(w => w.Name == searchCriteria).FirstOrDefault() == null)
                    txtSearchCriteria.Background = ((Brush)(new BrushConverter()).ConvertFromString("#00FF0000"));
                else
                    txtSearchCriteria.Background = ((Brush)(new BrushConverter()).ConvertFromString("#FFFF0000"));
            };
        }
        #region Events
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
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
        #endregion
        #region Private Methods
        private void ChangeRecipeImage(string fileLocation)
        {
            RecipeImage = new BitmapImage();
            RecipeImage.BeginInit();
            RecipeImage.UriSource = new Uri(fileLocation, UriKind.RelativeOrAbsolute);
            RecipeImage.EndInit();
        }
        #endregion
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            int prepTime, cookTime;
            if (!int.TryParse(txtPrepTime.Text, out prepTime))
                prepTime = 0;
            if (!int.TryParse(txtCookTime.Text, out cookTime))
                cookTime = 0;
            var totalTime = prepTime + cookTime;
            var ts = TimeSpan.FromMinutes(totalTime);
            tbTotalTime.Text = string.Format("{0}:{1}", ts.Hours, ts.Minutes);
        }
    }
}