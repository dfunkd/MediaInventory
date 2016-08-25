using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MediaInventory.Data;

namespace MediaInventory.Resources
{
    public class Globals : INotifyPropertyChanged
    {
        #region INotivyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        #region Private Properties
        private static List<string> _cellularCarriers;
        private SecurityRoles _currentRole = SecurityRoles.None;
        private InventoryUser _currentUser = null;
        private static Globals _default = null;
        private const int _defaultTimeoutPeriod = 300;
        private InventoryTypes _inventoryType = InventoryTypes.None;
        private PageTypes _pageType = PageTypes.None;
        private Customer _selectedCustomer = null;
        private Movie _selectedMovie = null;
        private MovieGroupHeaderTypes _movieGroupHeaderType = MovieGroupHeaderTypes.None;
        private Recipe _selectedRecipe = null;
        //private RecipeGroupHeaderTypes _recipeGroupHeaderType = RecipeGroupHeaderTypes.None;
        private int _timeoutPeriod = 300;
        #endregion
        #region Public Properties
        public static Globals Default
        {
            get
            {
                if (_default == null)
                    _default = new Globals();
                return _default;
            }
        }
        public static List<string> CelluarCarriers
        {
            get
            {
                if (_cellularCarriers == null || _cellularCarriers.Count == 0)
                {
                    _cellularCarriers = new List<string>();
                    _cellularCarriers.Add("@itelemigcelular.com.br");
                    _cellularCarriers.Add("@message.alltel.com");
                    _cellularCarriers.Add("@message.pioneerenidcellular.com");
                    _cellularCarriers.Add("@messaging.cellone-sf.com");
                    _cellularCarriers.Add("@messaging.centurytel.net");
                    _cellularCarriers.Add("@messaging.sprintpcs.com");
                    _cellularCarriers.Add("@mobile.att.net");
                    _cellularCarriers.Add("@mobile.cell1se.com");
                    _cellularCarriers.Add("@mobile.celloneusa.com");
                    _cellularCarriers.Add("@mobile.dobson.net");
                    _cellularCarriers.Add("@mobile.mycingular.com");
                    _cellularCarriers.Add("@mobile.mycingular.net");
                    _cellularCarriers.Add("@mobile.surewest.com");
                    _cellularCarriers.Add("@msg.acsalaska.com");
                    _cellularCarriers.Add("@msg.clearnet.com");
                    _cellularCarriers.Add("@msg.mactel.com");
                    _cellularCarriers.Add("@msg.myvzw.com");
                    _cellularCarriers.Add("@msg.telus.com");
                    _cellularCarriers.Add("@mycellular.com");
                    _cellularCarriers.Add("@mycingular.com");
                    _cellularCarriers.Add("@mycingular.net");
                    _cellularCarriers.Add("@mycingular.textmsg.com");
                    _cellularCarriers.Add("@o2.net.br");
                    _cellularCarriers.Add("@ondefor.com");
                    _cellularCarriers.Add("@pcs.rogers.com");
                    _cellularCarriers.Add("@personal-net.com.ar");
                    _cellularCarriers.Add("@personal.net.py");
                    _cellularCarriers.Add("@portafree.com");
                    _cellularCarriers.Add("@qwest.com");
                    _cellularCarriers.Add("@qwestmp.com");
                    _cellularCarriers.Add("@sbcemail.com");
                    _cellularCarriers.Add("@sms.bluecell.com");
                    _cellularCarriers.Add("@sms.cwjamaica.com");
                    _cellularCarriers.Add("@sms.edgewireless.com");
                    _cellularCarriers.Add("@sms.hickorytech.com");
                    _cellularCarriers.Add("@sms.net.nz");
                    _cellularCarriers.Add("@sms.pscel.com");
                    _cellularCarriers.Add("@smsc.vzpacifica.net");
                    _cellularCarriers.Add("@speedmemo.com");
                    _cellularCarriers.Add("@suncom1.com");
                    _cellularCarriers.Add("@sungram.com");
                    _cellularCarriers.Add("@telesurf.com.py");
                    _cellularCarriers.Add("@teletexto.rcp.net.pe");
                    _cellularCarriers.Add("@text.houstoncellular.net");
                    _cellularCarriers.Add("@text.telus.com");
                    _cellularCarriers.Add("@timnet.com");
                    _cellularCarriers.Add("@timnet.com.br");
                    _cellularCarriers.Add("@tms.suncom.com");
                    _cellularCarriers.Add("@tmomail.net");
                    _cellularCarriers.Add("@tsttmobile.co.tt");
                    _cellularCarriers.Add("@txt.bellmobility.ca");
                    _cellularCarriers.Add("@typetalk.ruralcellular.com");
                    _cellularCarriers.Add("@unistar.unifon.com.ar");
                    _cellularCarriers.Add("@uscc.textmsg.com");
                    _cellularCarriers.Add("@voicestream.net");
                    _cellularCarriers.Add("@vtext.com");
                    _cellularCarriers.Add("@wireless.bellsouth.com");
                }
                return _cellularCarriers.OrderBy(o => o).ToList();
            }
        }
        public SecurityRoles CurrentRole
        {
            get { return _currentRole; }
            set
            {
                if (_currentRole != value)
                {
                    _currentRole = value;
                    RaisePropertyChanged("CurrentRole");
                }
            }
        }
        public InventoryUser CurrentUser
        {
            get { return _currentUser; }
            set
            {
                if (_currentUser != value)
                {
                    _currentUser = value;
                    SetSecurityRole();
                    RaisePropertyChanged("CurrentUser");
                }
            }
        }
        public InventoryTypes InventoryType
        {
            get { return _inventoryType; }
            set
            {
                if (_inventoryType != value)
                {
                    _inventoryType = value;
                    RaisePropertyChanged("InventoryType");
                }
            }
        }
        public PageTypes PageType
        {
            get { return _pageType; }
            set
            {
                if (_pageType != value)
                {
                    _pageType = value;
                    RaisePropertyChanged("PageType");
                }
            }
        }
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    RaisePropertyChanged("SelectedCustomer");
                }
            }
        }
        public Movie SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                if (_selectedMovie != value)
                {
                    _selectedMovie = value;
                    RaisePropertyChanged("SelectedMovie");
                }
            }
        }
        public MovieGroupHeaderTypes MovieGroupHeaderType
        {
            get { return _movieGroupHeaderType; }
            set
            {
                if (_movieGroupHeaderType != value)
                {
                    _movieGroupHeaderType = value;
                    RaisePropertyChanged("MovieGroupHeaderType");
                }
            }
        }
        public Recipe SelectedRecipe
        {
            get { return _selectedRecipe; }
            set
            {
                if (_selectedRecipe != value)
                {
                    _selectedRecipe = value;
                    RaisePropertyChanged("SelectedRecipe");
                }
            }
        }
        //public RecipeGroupHeaderTypes RecipeGroupHeaderType
        //{
        //    get { return _recipeGroupHeaderType; }
        //    set
        //    {
        //        if (_recipeGroupHeaderType != value)
        //        {
        //            _recipeGroupHeaderType = value;
        //            RaisePropertyChanged("RecipeGroupHeaderType");
        //        }
        //    }
        //}
        public int TimeoutPeriod
        {
            get { return _timeoutPeriod; }
            set
            {
                if (_timeoutPeriod != value)
                {
                    _timeoutPeriod = value;
                    RaisePropertyChanged("TimeoutPeriod");
                }
            }
        }
        #endregion
        #region Private Methods
        private void SetSecurityRole()
        {
            if (CurrentUser == null)
            {
                Default.CurrentRole = SecurityRoles.None;
                return;
            }
            switch (CurrentUser.SecurityRole.Role)
            {
                case "Administrator":
                    Default.CurrentRole = SecurityRoles.Administrator;
                    break;
                case "Customer":
                    Default.CurrentRole = SecurityRoles.Customer;
                    break;
                case "Employee":
                    Default.CurrentRole = SecurityRoles.Employee;
                    break;
                default:
                    Default.CurrentRole = SecurityRoles.None;
                    break;
            }
        }
        #endregion
        #region Public Methods
        public static void ResetDefaultTimeoutPeriod()
        {
            Default.TimeoutPeriod = _defaultTimeoutPeriod;
        }
        #endregion
    }
}