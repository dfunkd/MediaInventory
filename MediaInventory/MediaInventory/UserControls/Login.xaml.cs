using MediaInventory.Data;
using MediaInventory.Resources;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MediaInventory.UserControls
{
    public partial class Login : UserControl
    {
        #region Custom Events
        #region ForgotLogin
        public delegate void ForgotLoginEventHander(ForgotTypes forgotType);
        public event ForgotLoginEventHander ForgotLoginEvent;
        public void RaiseForgotLoginEvent(ForgotTypes forgotType)
        {
            if (ForgotLoginEvent != null)
                ForgotLoginEvent(forgotType);
        }
        #endregion
        #region LoginCompleted
        public delegate void LoginCompletedEventHander();
        public event LoginCompletedEventHander LoginCompletedEvent;
        public void RaiseLoginCompletedEvent()
        {
            if (LoginCompletedEvent != null)
                LoginCompletedEvent();
        }
        #endregion
        #endregion
        #region Dependency Properties
        #region User
        public static readonly DependencyProperty UserProperty = DependencyProperty.Register("User", typeof(InventoryUser), typeof(Login), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None));
        public InventoryUser User
        {
            get { return (InventoryUser)GetValue(UserProperty); }
            set { SetValue(UserProperty, value); }
        }
        #endregion
        #endregion
        #region Routed Commands
        #region CancelLogin
        public static RoutedUICommand CancelLogin = new RoutedUICommand("Cancel", "CancelLogin", typeof(Login));
        private void CancelLoginExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            RaiseLoginCompletedEvent();
            e.Handled = true;
        }
        private void CanCancelLogin(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        #endregion
        #region ForgotLogin
        public static RoutedUICommand ForgotLogin = new RoutedUICommand("Forgot Login", "ForgotLogin", typeof(Login));
        private void ForgotLoginExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            RaiseForgotLoginEvent(ForgotTypes.Login);
            e.Handled = true;
        }
        private void CanForgotLogin(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        #endregion
        #region ForgotPassword
        public static RoutedUICommand ForgotPassword = new RoutedUICommand("Forgot Login", "ForgotPassword", typeof(Login));
        private void ForgotPasswordExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            RaiseForgotLoginEvent(ForgotTypes.Password);
            e.Handled = true;
        }
        private void CanForgotPassword(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        #endregion
        #region Login
        public static RoutedUICommand InventoryLogin = new RoutedUICommand("Login", "InventoryLogin", typeof(Login));
        private void InventoryLoginExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var users = Helpers.InventoryWindow.InventoryEntity.InventoryUsers.ToList();
            User = users.Where(w => w.DecryptedLogin == txtLogin.txtContent.Text.Trim() && w.DecryptedPassword == pwbPassword.pwbContent.Password.Trim()).FirstOrDefault();
            if (User != null)
            {
                Globals.Default.CurrentUser = User;
                RaiseLoginCompletedEvent();
            }
            else
                hccInvalidLogin.Visibility = Visibility.Visible;
        }
        private void CanInventoryLogin(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrWhiteSpace(txtLogin.txtContent.Text) && !string.IsNullOrWhiteSpace(pwbPassword.pwbContent.Password);
        }
        #endregion
        #endregion
        public Login()
        {
            InitializeComponent();
        }
        #region Events
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //txtLogin.txtContent.Focus();
            //txtLogin.Focus();
        }
        #endregion
    }
}