﻿using MediaInventory.Resources;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MediaInventory.UserControls
{
    public partial class AnimatedWatermarkTextBox : UserControl
    {
        #region Dependency Properties
        #region ContentBackground
        public static readonly DependencyProperty ContentBackgroundProperty = DependencyProperty.Register("ContentBackground", typeof(SolidColorBrush), typeof(AnimatedWatermarkTextBox),
            new FrameworkPropertyMetadata((SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000")), FrameworkPropertyMetadataOptions.None));
        public SolidColorBrush ContentBackground
        {
            get { return (SolidColorBrush)GetValue(ContentBackgroundProperty); }
            set { SetValue(ContentBackgroundProperty, value); }
        }
        #endregion
        #region ContentBorderBrush
        public static readonly DependencyProperty ContentBorderBrushProperty = DependencyProperty.Register("ContentBorderBrush", typeof(SolidColorBrush), typeof(AnimatedWatermarkTextBox),
            new FrameworkPropertyMetadata((SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000")), FrameworkPropertyMetadataOptions.None));
        public SolidColorBrush ContentBorderBrush
        {
            get { return (SolidColorBrush)GetValue(ContentBorderBrushProperty); }
            set { SetValue(ContentBorderBrushProperty, value); }
        }
        #endregion
        #region ContentSemiTransparentBackground
        public static readonly DependencyProperty ContentSemiTransparentBackgroundProperty = DependencyProperty.Register("ContentSemiTransparentBackground", typeof(SolidColorBrush), typeof(AnimatedWatermarkTextBox),
            new FrameworkPropertyMetadata((SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000")), FrameworkPropertyMetadataOptions.None));
        public SolidColorBrush ContentSemiTransparentBackground
        {
            get { return (SolidColorBrush)GetValue(ContentSemiTransparentBackgroundProperty); }
            set { SetValue(ContentSemiTransparentBackgroundProperty, value); }
        }
        #endregion
        #region ContentText
        public static readonly DependencyProperty ContentTextProperty = DependencyProperty.Register("ContentText", typeof(string), typeof(AnimatedWatermarkTextBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None));
        public string ContentText
        {
            get { return (string)GetValue(ContentTextProperty); }
            set { SetValue(ContentTextProperty, value); }
        }
        #endregion
        #region HeaderForeground
        public static readonly DependencyProperty HeaderForegroundProperty = DependencyProperty.Register("HeaderForeground", typeof(SolidColorBrush), typeof(AnimatedWatermarkTextBox),
            new FrameworkPropertyMetadata((SolidColorBrush)(new BrushConverter().ConvertFrom("#FF808080")), FrameworkPropertyMetadataOptions.None));
        public SolidColorBrush HeaderForeground
        {
            get { return (SolidColorBrush)GetValue(HeaderForegroundProperty); }
            set { SetValue(HeaderForegroundProperty, value); }
        }
        #endregion
        #region HeaderText
        public static readonly DependencyProperty HeaderTextProperty = DependencyProperty.Register("HeaderText", typeof(string), typeof(AnimatedWatermarkTextBox),
            new FrameworkPropertyMetadata("Testing", FrameworkPropertyMetadataOptions.None));
        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }
        #endregion
        #endregion
        public AnimatedWatermarkTextBox()
        {
            InitializeComponent();
            Loaded += (s, a) =>
            {
                ContentSemiTransparentBackground = GetOpacityColor(ContentBackground, 0.3);
                txtContent.Background = GetOpacityColor(ContentBackground, 0.3);
                txtContent.Foreground = Helpers.InvertColor(ContentBackground.ToString());
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
        #region Events
        private void OnTextBoxGofFocus(object sender, RoutedEventArgs e)
        {
            tbHeader.Visibility = string.IsNullOrWhiteSpace(txtContent.Text) ? Visibility.Visible : Visibility.Collapsed;
        }
        private void OnTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            tbHeader.Visibility = string.IsNullOrWhiteSpace(txtContent.Text) ? Visibility.Visible : Visibility.Collapsed;
        }
        private void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            tbHeader.Visibility = string.IsNullOrWhiteSpace(txtContent.Text) ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion
    }
}