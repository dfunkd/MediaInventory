using MediaInventory.Resources;
using MediaInventory.Resources.Animations;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MediaInventory.Windows
{
    public partial class CustomMessageBox : Window
    {
        #region Dependency Properties
        #region Caption
        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(CustomMessageBox), new FrameworkPropertyMetadata(string.Empty));
        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }
        #endregion
        #region ConfirmationMessage
        public static readonly DependencyProperty ConfirmationMessageProperty = DependencyProperty.Register("ConfirmationMessage", typeof(string), typeof(CustomMessageBox), new FrameworkPropertyMetadata(string.Empty));
        public string ConfirmationMessage
        {
            get { return (string)GetValue(ConfirmationMessageProperty); }
            set { SetValue(ConfirmationMessageProperty, value); }
        }
        #endregion
        #region DefaultResult
        public static readonly DependencyProperty DefaultResultProperty = DependencyProperty.Register("DefaultResult", typeof(MessageBoxResult), typeof(CustomMessageBox), new FrameworkPropertyMetadata(MessageBoxResult.None, new PropertyChangedCallback(OnDefaultResultChanged)));
        public MessageBoxResult DefaultResult
        {
            get { return (MessageBoxResult)GetValue(DefaultResultProperty); }
            set { SetValue(DefaultResultProperty, value); }
        }
        private static void OnDefaultResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CustomMessageBox)d).OnDefaultResultChanged(e);
        }
        protected virtual void OnDefaultResultChanged(DependencyPropertyChangedEventArgs e)
        {
            switch (DefaultResult)
            {
                case MessageBoxResult.Cancel:
                    messageCancelButton.IsDefault = true;
                    break;
                case MessageBoxResult.No:
                    messageNoButton.IsDefault = true;
                    break;
                case MessageBoxResult.None:
                    SetDefaultResultBasedOnDisplayedButtons();
                    break;
                case MessageBoxResult.OK:
                    messageOKButton.IsDefault = true;
                    break;
                case MessageBoxResult.Yes:
                    messageYesButton.IsDefault = true;
                    break;
                default:
                    break;
            }
        }
        #endregion
        #region DisplayButton
        public static readonly DependencyProperty DisplayButtonProperty = DependencyProperty.Register("DisplayButton", typeof(MessageBoxButton), typeof(CustomMessageBox), new FrameworkPropertyMetadata(MessageBoxButton.OK, new PropertyChangedCallback(OnDisplayButtonChanged)));
        public MessageBoxButton DisplayButton
        {
            get { return (MessageBoxButton)GetValue(DisplayButtonProperty); }
            set { SetValue(DisplayButtonProperty, value); }
        }
        private static void OnDisplayButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CustomMessageBox)d).OnDisplayButtonChanged(e);
        }
        protected virtual void OnDisplayButtonChanged(DependencyPropertyChangedEventArgs e)
        {
            messageNoButton.Visibility = (DisplayButton == MessageBoxButton.YesNo || DisplayButton == MessageBoxButton.YesNoCancel) ? Visibility.Visible : Visibility.Collapsed;
            messageYesButton.Visibility = (DisplayButton == MessageBoxButton.YesNo || DisplayButton == MessageBoxButton.YesNoCancel) ? Visibility.Visible : Visibility.Collapsed;
            messageOKButton.Visibility = (DisplayButton == MessageBoxButton.OK || DisplayButton == MessageBoxButton.OKCancel) ? Visibility.Visible : Visibility.Collapsed;
            messageCancelButton.Visibility = (DisplayButton == MessageBoxButton.OKCancel || DisplayButton == MessageBoxButton.YesNoCancel) ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion
        #region IsConfirmed
        public static readonly DependencyProperty IsConfirmedProperty = DependencyProperty.Register("IsConfirmed", typeof(bool), typeof(CustomMessageBox), new FrameworkPropertyMetadata(false));
        public bool IsConfirmed
        {
            get { return (bool)GetValue(IsConfirmedProperty); }
            set { SetValue(IsConfirmedProperty, value); }
        }
        #endregion
        #region MessageBoxIcon
        public static readonly DependencyProperty MessageBoxIconProperty = DependencyProperty.Register("MessageBoxIcon", typeof(MessageBoxImage), typeof(CustomMessageBox), new FrameworkPropertyMetadata(MessageBoxImage.None, new PropertyChangedCallback(OnMessageBoxIconChanged)));
        public MessageBoxImage MessageBoxIcon
        {
            get { return (MessageBoxImage)GetValue(MessageBoxIconProperty); }
            set { SetValue(MessageBoxIconProperty, value); }
        }
        private static void OnMessageBoxIconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CustomMessageBox)d).OnMessageBoxIconChanged(e);
        }
        protected virtual void OnMessageBoxIconChanged(DependencyPropertyChangedEventArgs e)
        {
            messageBoxImage.Visibility = Visibility.Visible;
            Uri icon;
            switch (MessageBoxIcon)
            {
                case MessageBoxImage.Error:
                    icon = new Uri("pack://application:,,,/MediaInventory;component/Resources/Images/Question.png");
                    messageBoxImage.Source = new BitmapImage(icon);
                    break;
                case MessageBoxImage.Information:
                    icon = new Uri("pack://application:,,,/MediaInventory;component/Resources/Images/Information.png");
                    messageBoxImage.Source = new BitmapImage(icon);
                    break;
                case MessageBoxImage.Question:
                    icon = new Uri("pack://application:,,,/MediaInventory;component/Resources/Images/Question.png");
                    messageBoxImage.Source = new BitmapImage(icon);
                    break;
                case MessageBoxImage.Warning:
                    icon = new Uri("pack://application:,,,/MediaInventory;component/Resources/Images/Exclamation.png");
                    messageBoxImage.Source = new BitmapImage(icon);
                    break;
                case MessageBoxImage.None:
                default:
                    messageBoxImage.Visibility = Visibility.Collapsed;
                    break;
            }
        }
        #endregion
        #region MessageText
        public static readonly DependencyProperty MessageTextProperty = DependencyProperty.Register("MessageText", typeof(string), typeof(CustomMessageBox), new FrameworkPropertyMetadata(string.Empty));
        public string MessageText
        {
            get { return (string)GetValue(MessageTextProperty); }
            set { SetValue(MessageTextProperty, value); }
        }
        #endregion
        #region Result
        public static readonly DependencyProperty ResultProperty = DependencyProperty.Register("Result", typeof(MessageBoxResult), typeof(CustomMessageBox), new FrameworkPropertyMetadata(MessageBoxResult.None));
        public MessageBoxResult Result
        {
            get { return (MessageBoxResult)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }
        #endregion
        #endregion
        #region Constructors
        public CustomMessageBox()
        {
            InitializeComponent();
            Loaded += (s, a) =>
            {
                BounceAnimation.Play(this);
                tbHeader.Foreground = Helpers.InvertColor(bdrHeader.Background.ToString());
                tbMessage.Foreground = Helpers.InvertColor(bdrMessage.Background.ToString());
            };
        }
        #endregion
        #region Events
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void messageCancelButton_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Cancel;
            Close();
        }
        private void messageNoButton_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.No;
            Close();
        }
        private void messageOKButton_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.OK;
            Close();
        }
        private void messageYesButton_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Yes;
            Close();
        }
        private void SetDefaultResultBasedOnDisplayedButtons()
        {
            messageCancelButton.IsDefault = messageNoButton.IsDefault = messageOKButton.IsDefault = messageYesButton.IsDefault = false;
            switch (DisplayButton)
            {
                case MessageBoxButton.OK:
                    messageOKButton.IsDefault = true;
                    break;
                case MessageBoxButton.OKCancel:
                    messageOKButton.IsDefault = true;
                    break;
                case MessageBoxButton.YesNo:
                    messageYesButton.IsDefault = true;
                    break;
                case MessageBoxButton.YesNoCancel:
                    messageYesButton.IsDefault = true;
                    break;
                default:
                    break;
            }
        }
        #endregion
        #region Public Static Methods
        public static MessageBoxResult Show(string message, Window owner, string confirmationMessage = null)
        {
            return Show(message, string.Empty, MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.None, owner, confirmationMessage: confirmationMessage);
        }
        public static MessageBoxResult Show(string message, string caption, Window owner, string confirmationMessage = null)
        {
            return Show(message, caption, MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.None, owner, confirmationMessage: confirmationMessage);
        }
        public static MessageBoxResult Show(string message, string caption, MessageBoxButton button, Window owner, string confirmationMessage = null)
        {
            return Show(message, caption, button, MessageBoxImage.None, MessageBoxResult.None, owner, confirmationMessage: confirmationMessage);
        }
        public static MessageBoxResult Show(string message, string caption, MessageBoxButton button, MessageBoxImage icon, Window owner = null, string confirmationMessage = null)
        {
            return Show(message, caption, button, icon, MessageBoxResult.None, owner, confirmationMessage: confirmationMessage);
        }
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, Window owner, string confirmationMessage = null)
        {
            bool isConfirmed = false;
            return Show(messageBoxText, caption, button, icon, defaultResult, out isConfirmed, owner, confirmationMessage: confirmationMessage);
        }
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, out bool isConfirmed, Window owner, string confirmationMessage = null)
        {
            CustomMessageBox box = new CustomMessageBox();
            box.MessageText = messageBoxText;
            box.Caption = caption;
            box.DisplayButton = button;
            box.DefaultResult = defaultResult;
            box.ConfirmationMessage = confirmationMessage;
            if (defaultResult == MessageBoxResult.None)
                box.SetDefaultResultBasedOnDisplayedButtons();
            box.MessageBoxIcon = icon;
            switch (box.DisplayButton)
            {
                case MessageBoxButton.OK:
                    break;
                case MessageBoxButton.OKCancel:
                    box.messageCancelButton.IsCancel = true;
                    break;
                case MessageBoxButton.YesNo:
                    break;
                case MessageBoxButton.YesNoCancel:
                    box.messageCancelButton.IsCancel = true;
                    break;
                default:
                    break;
            }
            if (owner == null)
            {
                if (Application.Current.MainWindow != null && Application.Current.MainWindow.IsVisible)
                    box.Owner = Application.Current.MainWindow; // bad for full screen window!
            }
            else
            {
                box.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                box.Owner = owner;
            }
            box.ShowDialog();
            isConfirmed = box.IsConfirmed;
            return box.Result;
        }
        #endregion
    }
}