using MediaInventory.Resources;
using MediaInventory.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MediaInventory.UserControls
{
    public partial class ForgotLoginPassword : UserControl
    {
        #region Custom Events
        public delegate void ForgotLoginPasswordCompletedEventHander();
        public event ForgotLoginPasswordCompletedEventHander ForgotLoginPasswordCompletedEvent;
        public void RaiseForgotLoginPasswordCompletedEvent()
        {
            if (ForgotLoginPasswordCompletedEvent != null)
                ForgotLoginPasswordCompletedEvent();
        }
        #endregion
        #region Dependency Properties
        #region ForgotType
        public static readonly DependencyProperty ForgotTypeProperty = DependencyProperty.Register("ForgotType", typeof(ForgotTypes), typeof(ForgotLoginPassword), new FrameworkPropertyMetadata(ForgotTypes.Login, FrameworkPropertyMetadataOptions.None));
        public ForgotTypes ForgotType
        {
            get { return (ForgotTypes)GetValue(ForgotTypeProperty); }
            set { SetValue(ForgotTypeProperty, value); }
        }
        #endregion
        #endregion
        #region Routed Commands
        #region Cancel
        public static RoutedUICommand Cancel = new RoutedUICommand("Send", "Cancel", typeof(ForgotLoginPassword));
        private void CancelExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            RaiseForgotLoginPasswordCompletedEvent();
        }
        private void CanCancel(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        #endregion
        #region SendInformation
        public static RoutedUICommand SendInformation = new RoutedUICommand("Send", "SendInformation", typeof(ForgotLoginPassword));
        private void SendInformationExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var users = Helpers.InventoryWindow.InventoryEntity.InventoryUsers.ToList();
            users = users.Where(w=>w.DecryptedEmail == txtEmail.txtContent.Text && w.DecryptedCell == mtbCell.Content.Text).ToList();
            if (ForgotType == ForgotTypes.Login)
                users = users.Where(w => w.DecryptedPassword == pwbPassword.pwbContent.Password).ToList();
            if (ForgotType == ForgotTypes.Password)
                users = users.Where(w => w.DecryptedLogin == txtLogin.txtContent.Text).ToList();
            if (users.Count == 0)
                CustomMessageBox.Show("There are no user meeting the provided criteria.  Please contact the system administrator at dylanpfunk4@yahoo.com or create a new account.", "Not enough Information", MessageBoxButton.OK, MessageBoxImage.Question);
            else if (users.Count > 1)
            {
                if (ForgotType == ForgotTypes.Login)
                    CustomMessageBox.Show("Not enough information to provide your password.  Please contact the system administrator at dylanpfunk4@yahoo.com.", "Not enough Information", MessageBoxButton.OK, MessageBoxImage.Question);
                else if (ForgotType == ForgotTypes.Password)
                    CustomMessageBox.Show("Not enough information to provide your password.  Please contact the system administrator at dylanpfunk4@yahoo.com.", "Not enough Information", MessageBoxButton.OK, MessageBoxImage.Question);
            }
            else
            {
                //TODO:  Change this to either send and Email or Text with the information requested.
                if (ForgotType == ForgotTypes.Login)
                    CustomMessageBox.Show(string.Format("Your Login is {0}.", users.Select(s => s.DecryptedLogin).FirstOrDefault()), "Login Recovery", MessageBoxButton.OK, MessageBoxImage.Question);
                if (ForgotType == ForgotTypes.Password)
                    CustomMessageBox.Show(string.Format("Your Password is {0}.", users.Select(s => s.DecryptedPassword).FirstOrDefault()), "Password Recovery", MessageBoxButton.OK, MessageBoxImage.Question);
                RaiseForgotLoginPasswordCompletedEvent();
            }
        }
        private void CanSendInformation(object sender, CanExecuteRoutedEventArgs e)
        {
             e.CanExecute = (ForgotType == ForgotTypes.Password) ? mtbCell.IsValid && !string.IsNullOrWhiteSpace(txtEmail.txtContent.Text) && !string.IsNullOrWhiteSpace(txtLogin.txtContent.Text)
                : !string.IsNullOrWhiteSpace(pwbPassword.pwbContent.Password) && (!string.IsNullOrWhiteSpace(txtEmail.txtContent.Text) && mtbCell.IsValid);
        }
        #endregion
        #endregion
        public ForgotLoginPassword()
        {
            InitializeComponent();
        }
        #region Events
        #endregion
        #region Functions
        #endregion
    }
}