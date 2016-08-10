using MediaInventory.Resources;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace MediaInventory.UserControls
{
    public partial class MaskedTextBoxWithHeader : UserControl
    {
        #region Dependency Properties
        #region ContentBackground
        public static readonly DependencyProperty ContentBackgroundProperty = DependencyProperty.Register("ContentBackground", typeof(SolidColorBrush), typeof(MaskedTextBoxWithHeader),
            new FrameworkPropertyMetadata((SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000")), FrameworkPropertyMetadataOptions.None));
        public SolidColorBrush ContentBackground
        {
            get { return (SolidColorBrush)GetValue(ContentBackgroundProperty); }
            set { SetValue(ContentBackgroundProperty, value); }
        }
        #endregion
        #region ContentBorderBrush
        public static readonly DependencyProperty ContentBorderBrushProperty = DependencyProperty.Register("ContentBorderBrush", typeof(SolidColorBrush), typeof(MaskedTextBoxWithHeader),
            new FrameworkPropertyMetadata((SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000")), FrameworkPropertyMetadataOptions.None));
        public SolidColorBrush ContentBorderBrush
        {
            get { return (SolidColorBrush)GetValue(ContentBorderBrushProperty); }
            set { SetValue(ContentBorderBrushProperty, value); }
        }
        #endregion
        #region ContentMask
        public static readonly DependencyProperty ContentMaskProperty = DependencyProperty.Register("ContentMask", typeof(string), typeof(MaskedTextBoxWithHeader), new FrameworkPropertyMetadata(string.Empty));
        public string ContentMask
        {
            get { return (string)GetValue(ContentMaskProperty); }
            set { SetValue(ContentMaskProperty, value); }
        }
        #endregion
        #region ContentMaskValueDataType
        public static readonly DependencyProperty ContentMaskValueDataTypeProperty = DependencyProperty.Register("ContentMaskValueDataType", typeof(Type), typeof(MaskedTextBoxWithHeader), new FrameworkPropertyMetadata(null));
        public Type ContentMaskValueDataType
        {
            get { return (Type)GetValue(ContentMaskValueDataTypeProperty); }
            set { SetValue(ContentMaskValueDataTypeProperty, value); }
        }
        #endregion
        #region ContentSemiTransparentBackground
        public static readonly DependencyProperty ContentSemiTransparentBackgroundProperty = DependencyProperty.Register("ContentSemiTransparentBackground", typeof(SolidColorBrush), typeof(MaskedTextBoxWithHeader),
            new FrameworkPropertyMetadata((SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000")), FrameworkPropertyMetadataOptions.None));
        public SolidColorBrush ContentSemiTransparentBackground
        {
            get { return (SolidColorBrush)GetValue(ContentSemiTransparentBackgroundProperty); }
            set { SetValue(ContentSemiTransparentBackgroundProperty, value); }
        }
        #endregion
        #region ContentText
        public static readonly DependencyProperty ContentTextProperty = DependencyProperty.Register("ContentText", typeof(string), typeof(MaskedTextBoxWithHeader),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None));
        public string ContentText
        {
            get { return (string)GetValue(ContentTextProperty); }
            set { SetValue(ContentTextProperty, value); }
        }
        #endregion
        #region HeaderForeground
        public static readonly DependencyProperty HeaderForegroundProperty = DependencyProperty.Register("HeaderForeground", typeof(SolidColorBrush), typeof(MaskedTextBoxWithHeader),
            new FrameworkPropertyMetadata((SolidColorBrush)(new BrushConverter().ConvertFrom("#FF808080")), FrameworkPropertyMetadataOptions.None));
        public SolidColorBrush HeaderForeground
        {
            get { return (SolidColorBrush)GetValue(HeaderForegroundProperty); }
            set { SetValue(HeaderForegroundProperty, value); }
        }
        #endregion
        #region HeaderText
        public static readonly DependencyProperty HeaderTextProperty = DependencyProperty.Register("HeaderText", typeof(string), typeof(MaskedTextBoxWithHeader),
            new FrameworkPropertyMetadata("Testing", FrameworkPropertyMetadataOptions.None));
        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }
        #endregion
        #region IsValid
        public static readonly DependencyProperty IsValidProperty = DependencyProperty.Register("IsValid", typeof(bool), typeof(MaskedTextBoxWithHeader), new FrameworkPropertyMetadata(false));
        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }
        #endregion
        #endregion
        public MaskedTextBoxWithHeader()
        {
            InitializeComponent();
            Loaded += (s, a) =>
            {
                Content.Background = GetOpacityColor(ContentBackground, 0.3);
                Content.BorderBrush = ContentBorderBrush;
                Content.Foreground = Helpers.InvertColor(ContentBackground.ToString());
                Content.Mask = ContentMask;
                Content.ValueDataType = ContentMaskValueDataType;
                Header.Foreground = Helpers.InvertColor(ContentBackground.ToString());
                Header.Text = HeaderText;
                HeaderBorder.Background = GetOpacityColor(ContentBackground, 0.6);
                HeaderBorder.BorderBrush = Content.BorderBrush;
            };
        }
        private SolidColorBrush GetOpacityColor(SolidColorBrush solidColorBrush, double opacityPercentage)
        {
            var opacity = solidColorBrush.Color.ToString().Substring(1, 2);
            var color = solidColorBrush.Color.ToString().Substring(3, 6);
            int offset = int.Parse(opacity, System.Globalization.NumberStyles.HexNumber);
            int offset2 = Convert.ToInt32(Math.Round(offset * opacityPercentage, MidpointRounding.AwayFromZero));
            return (SolidColorBrush)new BrushConverter().ConvertFrom(string.Format("#{0:X}{1:X}", offset2, color));
        }
        private void OnTextBoxGofFocus(object sender, RoutedEventArgs e)
        {

        }
        private void OnTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            var mtb = sender as MaskedTextBox;
            ContentBorder.BorderBrush = (!mtb.IsMaskFull) ? (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFF0000") : (SolidColorBrush)new BrushConverter().ConvertFrom("#000000");
            IsValid = mtb.IsMaskFull;
        }
    }
}