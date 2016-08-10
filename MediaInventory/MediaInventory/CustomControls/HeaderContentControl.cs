using System.Windows;
using System.Windows.Controls;

namespace MediaInventory.CustomControls
{
    public class HeaderContentControl : ContentControl
    {
        #region Dependency Properties
        #region Header
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(object), typeof(HeaderContentControl), new FrameworkPropertyMetadata((object)null));
        public object Header
        {
            get { return GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
        #endregion
        #endregion
        #region Constructors
        static HeaderContentControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HeaderContentControl), new FrameworkPropertyMetadata(typeof(HeaderContentControl)));
        }
        public HeaderContentControl()
        {
            Focusable = false;
        }
        #endregion
    }
}