using MediaInventory.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TMDbLib.Objects.General;

namespace MediaInventory.Resources
{
    #region Multi Value Converters
    public class MeasurementConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string errorString = string.Empty;
            if (!(string.IsNullOrWhiteSpace(values[0].ToString()) && string.IsNullOrWhiteSpace(values[1].ToString())))
            {
                decimal qty;
                if (!decimal.TryParse(values[0].ToString(), out qty))
                    errorString = "Invalid Quantity";
                return string.IsNullOrWhiteSpace(errorString) ? string.Format("{0} {1}", qty, values[1].ToString()) : errorString;
            }
            return "Invalid Quantity or Measurement value passed in.";
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class TotalPrepCookTimeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int totalMinutes = 0;
            foreach (var value in values)
            {
                if (!(value is int))
                    return null;
                int minutes;
                if (int.TryParse(value.ToString(), out minutes))
                    totalMinutes += minutes;
            }
            var ts = TimeSpan.FromMinutes(totalMinutes);
            return ts.ToString(@"h:mm");
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    #region Value Converters
    public class BinaryToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is byte[]))
                return null;
            return Helpers.BytesToImageSource(value as byte[]);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ImageSource))
                return null;
            return Helpers.ImageSourceToBytes(new PngBitmapEncoder(), value as ImageSource);
        }
    }
    public class BooleanTrueToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Collapsed;
            if (value is bool)
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            return Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    public class CheckOutEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Movie))
                return false;
            var isValidUser = Globals.Default.CurrentRole == SecurityRoles.Administrator || Globals.Default.CurrentRole == SecurityRoles.Employee;
            var isOwned = (value as Movie).IsOwned;
            return isValidUser && isOwned;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class DateTimeToDateAndTimeOrNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;
            var dateTime = DateTime.Parse(value.ToString());
            return string.Format("{0:MMMM d, yyyy} @ {0:t}", dateTime);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    public class EmptyStringToCollapsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string.IsNullOrWhiteSpace(value.ToString())) ? Visibility.Collapsed : Visibility.Visible;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ForgotTypeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()) && parameter != null && !string.IsNullOrWhiteSpace(parameter.ToString()))
            {
                var param = (ForgotTypes)parameter;
                var type = (ForgotTypes)value;
                return param == type ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && !string.IsNullOrWhiteSpace(parameter.ToString()))
                return (ForgotTypes)parameter;
            return null;
        }
    }
    public class GenreListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<Genre>)
            {
                var retString = string.Empty;
                foreach (Genre genre in value as List<Genre>)
                {
                    if (!string.IsNullOrWhiteSpace(retString))
                        retString += ", ";
                    retString += genre.Name;
                }
                return retString;
            }
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    public class InventoryTypeToIsCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()) && parameter != null && !string.IsNullOrWhiteSpace(parameter.ToString()))
            {
                var param = (InventoryTypes)parameter;
                var type = (InventoryTypes)value;
                if (type == InventoryTypes.None)
                    return false;
                return param == type;
            }
            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && !string.IsNullOrWhiteSpace(parameter.ToString()))
                return (InventoryTypes)parameter;
            return InventoryTypes.None;
        }
    }
    public class IsCheckedOutToAlternateRowColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush colorBrush;
            if (!(value is bool))
                colorBrush = new SolidColorBrush(Colors.Transparent);
            colorBrush = (bool)value ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF9A4D4C")) : (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF5A7BAD"));//356C38 - Green-FF46638E
            return colorBrush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    public class IsCheckedOutToBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Movie))
                return (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB46765"));
            var movie = value as Movie;
            if (movie.IsOwned)
                return movie.IsCheckedOut ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB46765")) : (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF5CA461"));
            return (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB46765"));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    public class IsCheckedOutToRowColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Movie))
                return (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB3B465"));
            var movie = value as Movie;
            if(movie.IsOwned)
                return (value as Movie).IsCheckedOut ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF783C3B")) : (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF46638E"));//356C38 - Dark Green
            return (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB3B465"));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    public class IsCheckedOutToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Movie))
                return string.Empty;
            var movie = value as Movie;
            if (movie.IsOwned)
                return (value as Movie).IsCheckedOut ? "Checked Out" : "Available";
            return "Not Owned";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    public class IsWantedOwnedBackgroumdConnverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Movie)
            {
                var movie = value as Movie;
                if (movie.IsOwned)
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#FF5CA461");
                if (movie.IsWanted)
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#FFB2B365");
                return (SolidColorBrush)new BrushConverter().ConvertFrom("#FFB46765");
            }
            return (SolidColorBrush)new BrushConverter().ConvertFrom("#FFB46765");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class IsWantedOwnedTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Movie)
            {
                var movie = value as Movie;
                if (movie.IsOwned)
                    return "Owned";
                if (movie.IsWanted)
                    return "Wanted";
                return "Not Owned";
            }
            return "Invalid Type";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class MovieGroupHeaderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is Format && Globals.Default.MovieGroupHeaderType == MovieGroupHeaderTypes.Format)
                    return (value as Format).Name;
                else if (value is bool)
                {
                    if (Globals.Default.MovieGroupHeaderType == MovieGroupHeaderTypes.CheckStatus)
                        return bool.Parse(value.ToString()) ? "Checked Out Movie" : "Checked In Movie";
                    else if (Globals.Default.MovieGroupHeaderType == MovieGroupHeaderTypes.Owned)
                        return bool.Parse(value.ToString()) ? "Owned Movie" : "Not Owned Movie";
                    else if (Globals.Default.MovieGroupHeaderType == MovieGroupHeaderTypes.Wanted)
                        return bool.Parse(value.ToString()) ? "Wanted Movie" : "Not Wanted Movie";
                }
                return string.Empty;
            }
            else
                return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class MovieGroupHeaderPluralConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int count;
            return int.TryParse(value.ToString(), out count) ? (count > 1 ? "s" : string.Empty) : string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class NullToCollapsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Visible;
            if (value is Uri)
                return !string.IsNullOrWhiteSpace((value as Uri).AbsolutePath) ? Visibility.Collapsed : Visibility.Visible;
            else if (!string.IsNullOrWhiteSpace(value.ToString()))
                return Visibility.Collapsed;
            else if (value is DateTime)
                return Visibility.Collapsed;
            return Visibility.Visible;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    public class NullToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty((string)value) ? parameter : value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Collapsed;
            if (value is Uri)
                return !string.IsNullOrWhiteSpace((value as Uri).AbsolutePath) ? Visibility.Visible : Visibility.Collapsed;
            else if (!string.IsNullOrWhiteSpace(value.ToString()))
                return Visibility.Visible;
            else if (value is DateTime)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    public class PrepCookTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int))
                return null;
            int minutes;
            int.TryParse(value.ToString(), out minutes);
            var ts = TimeSpan.FromMinutes(minutes);
            return ts.ToString(@"h\:mm");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(value.ToString()))
                return null;
            TimeSpan ts;
            if (!TimeSpan.TryParse(value.ToString(), out ts))
                return null;
            return ts.TotalMinutes;
        }
    }
    public class StringContentToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Collapsed;
            var stringValue = value is string ? (string)value : value.ToString();
            return stringValue.HasContent() ? Visibility.Visible : Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ValuationTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Recipe))
                return string.Empty;
            var recipe = value as Recipe;
            if (recipe.Valuation == null)
                return "Unknown";
            return recipe.Valuation.Value ? "Good" : "Bad";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ValuationBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Recipe)
            {
                var recipe = value as Recipe;
                if (!recipe.Valuation.HasValue)
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#FFB2B365");
                if (recipe.Valuation.Value)
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#FF5CA461");
                return (SolidColorBrush)new BrushConverter().ConvertFrom("#FFB46765");
            }
            return (SolidColorBrush)new BrushConverter().ConvertFrom("#FF6A6A6A");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}