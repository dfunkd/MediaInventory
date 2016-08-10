using MediaInventory.Data;
using MediaInventory.Resources;
using MediaInventory.UserControls;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MediaInventory
{
    public partial class Inventory : Window
    {
        #region Dependency Properties
        #region CurrentUserAndRole
        public static readonly DependencyProperty CurrentUserAndRoleProperty = DependencyProperty.Register("CurrentUserAndRole", typeof(string), typeof(Inventory), new FrameworkPropertyMetadata(string.Empty));
        public string CurrentUserAndRole
        {
            get { return (string)GetValue(CurrentUserAndRoleProperty); }
            set { SetValue(CurrentUserAndRoleProperty, value); }
        }
        #endregion
        #region InventoryEntity
        public static readonly DependencyProperty InventoryEntityProperty = DependencyProperty.Register("InventoryEntity", typeof(InventoryEntities), typeof(Inventory), new FrameworkPropertyMetadata(DataHelper.Default.Entity));
        public InventoryEntities InventoryEntity
        {
            get { return (InventoryEntities)GetValue(InventoryEntityProperty); }
            set { SetValue(InventoryEntityProperty, value); }
        }
        #endregion
        #region IsLoggedIn
        public static readonly DependencyProperty IsLoggedInProperty = DependencyProperty.Register("IsLoggedIn", typeof(bool), typeof(Inventory), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.None));
        public bool IsLoggedIn
        {
            get { return (bool)GetValue(IsLoggedInProperty); }
            set { SetValue(IsLoggedInProperty, value); }
        }
        #endregion
        #endregion
        #region Routed Commands
        #region AddInventory
        public static RoutedUICommand AddInventory = new RoutedUICommand("Add", "AddInventory", typeof(Inventory));
        private void AddInventoryExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Globals.Default.PageType = PageTypes.Add;
            ccMain.Content = new Add { InventoryType = Globals.Default.InventoryType };
        }
        private void CanAddInventory(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Globals.Default.PageType != PageTypes.Add;
        }
        #endregion
        #region CloseApplication
        public static RoutedUICommand CloseApplication = new RoutedUICommand("", "CloseApplication", typeof(Inventory));
        private void CloseApplicationExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
        private void CanCloseApplication(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        #endregion
        #region EditInventory
        public static RoutedUICommand EditInventory = new RoutedUICommand("Edit", "EditInventory", typeof(Inventory));
        private void EditInventoryExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Globals.Default.PageType = PageTypes.Edit;
            ccMain.Content = new Edit { InventoryType = Globals.Default.InventoryType };
        }
        private void CanEditInventory(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Globals.Default.PageType != PageTypes.Edit;
        }
        #endregion
        #region Login
        public static RoutedUICommand Login = new RoutedUICommand("Login", "Login", typeof(Inventory));
        private void LoginExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var login = new Login();
            ccMain.Content = login;
            login.ForgotLoginEvent += (t) =>
            {
                var forgot = new ForgotLoginPassword { ForgotType = t };
                ccMain.Content = forgot;
                forgot.ForgotLoginPasswordCompletedEvent += () =>
                {
                    LoginExecuted(null, null);
                };
            };
            login.LoginCompletedEvent += () =>
            {
                ccMain.Content = null;
                IsLoggedIn = true;
                CurrentUserAndRole = string.Format("{0} ({1})", Globals.Default.CurrentUser.DecryptedLogin, Globals.Default.CurrentRole);
                SetupMenuItems();
            };
        }
        private void CanLogin(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Globals.Default.CurrentUser == null;
        }
        #endregion
        #region Logout
        public static RoutedUICommand Logout = new RoutedUICommand("Logout", "Logout", typeof(Inventory));
        private void LogoutExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Globals.Default.CurrentUser = null;
            IsLoggedIn = false;
            CurrentUserAndRole = null;
            ccMain.Content = null;
        }
        private void CanLogout(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Globals.Default.CurrentUser != null;
        }
        #endregion
        #region OpenSettings
        public static RoutedUICommand OpenSettings = new RoutedUICommand("OpenSettings", "OpenSettings", typeof(Inventory));
        private void OpenSettingsExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var settings = new InventorySettings();
            ccMain.Content = settings;
        }
        private void CanOpenSettings(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Globals.Default.CurrentUser != null;
        }
        #endregion
        #region SearchInventory
        public static RoutedUICommand SearchInventory = new RoutedUICommand("Search", "SearchInventory", typeof(Inventory));
        private void SearchInventoryExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Globals.Default.PageType = PageTypes.Search;
            ccMain.Content = new Search { InventoryType = Globals.Default.InventoryType };
        }
        private void CanSearchInventory(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Globals.Default.PageType != PageTypes.Search;
        }
        #endregion
        #endregion
        public Inventory()
        {
            InitializeComponent();
            Helpers.InventoryWindow = this;
            Globals.Default.PropertyChanged += Default_PropertyChanged;
            Loaded += (s, a) =>
            {
                //BEGIN - remove before release or to test login
                Globals.Default.CurrentUser = DataHelper.Default.Users.Where(w => w.DecryptedLogin == "dfunkdAdmin").FirstOrDefault();
                IsLoggedIn = true;
                CurrentUserAndRole = string.Format("{0} ({1})", Globals.Default.CurrentUser.DecryptedLogin, Globals.Default.CurrentRole);
                //END - remove before release or to test login
                SetupMenuItems();
            };
        }
        #region Events
        private void Default_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "CurrentRole":
                    SetupMenuItems();
                    break;
                case "CurrentUser":
                    break;
                case "SelectedMovie":
                    break;
                case "SelectedCustomer":
                    break;
            }
        }
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        #endregion
        #region Methods
        private void SetupMenuItems()
        {
            var role = Globals.Default.CurrentRole;
            var user = Globals.Default.CurrentUser;
            btnAdd.Visibility = user != null && (role == SecurityRoles.Administrator || role == SecurityRoles.Employee) ? Visibility.Visible : Visibility.Collapsed;
            btnEdit.Visibility = user != null && (role == SecurityRoles.Administrator || role == SecurityRoles.Employee) ? Visibility.Visible : Visibility.Collapsed;
            btnLogin.Visibility = user == null ? Visibility.Visible : Visibility.Collapsed;
            btnLogout.Visibility = user != null ? Visibility.Visible : Visibility.Collapsed;
            btnSearch.Visibility = user != null && role != SecurityRoles.None ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion
    }
}