using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace MediaInventory.Data
{
    public class DataHelper : INotifyPropertyChanged
    {
        #region INotivyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        //#region Predicates
        //public AutoCompleteFilterPredicate<object> CustomerFilter
        //{
        //    get
        //    {
        //        return (searchText, obj) => (obj as Customer).FirstName.Contains(searchText)
        //                                 || (obj as Customer).LastName.Contains(searchText)
        //                                 || (obj as Customer).EmailAddress.Contains(searchText)
        //                                 || (obj as Customer).HomePhone.Contains(searchText)
        //                                 || (obj as Customer).CellPhone.Contains(searchText);
        //    }
        //}
        //#endregion
        #region Private Properties
        private ObservableCollection<CheckOutHistory> _checkOutHistories;
        private ObservableCollection<string> _customerNames;
        private ObservableCollection<Customer> _customers;
        private static DataHelper _defaultInstance;
        private InventoryEntities _entity;
        private ObservableCollection<Format> _formats;
        private ListCollectionView _movieCollection;
        private ObservableCollection<Movie> _movies;
        private ObservableCollection<SecurityQuestion> _securityQuestions;
        private ObservableCollection<SecurityRole> _securityRoles;
        private ObservableCollection<State> _states;
        private ObservableCollection<InventoryUser> _users;
        #endregion
        #region Public Properties
        public ObservableCollection<CheckOutHistory> CheckOutHistories
        {
            get
            {
                if (_checkOutHistories == null)
                    _checkOutHistories = new ObservableCollection<CheckOutHistory>(Entity.CheckOutHistories.ToList());
                return _checkOutHistories;
            }
            private set
            {
                if (_checkOutHistories != null && value != null && !_checkOutHistories.Equals(value))
                {
                    _checkOutHistories = value;
                    if (PropertyChanged != null)
                        RaisePropertyChanged("CheckOutHistories");
                }
            }
        }
        public ObservableCollection<Customer> Customers
        {
            get
            {
                if (_customers == null)
                    _customers = new ObservableCollection<Customer>(Entity.Customers.ToList());
                return _customers;
            }
            private set
            {
                if (_customers != null && value != null && !_customers.Equals(value))
                {
                    _customers = value;
                    if (PropertyChanged != null)
                        RaisePropertyChanged("Customers");
                }
            }
        }
        public ObservableCollection<string> CustomerNames
        {
            get
            {
                if (_customerNames == null)
                    _customerNames = new ObservableCollection<string>(Entity.Customers.Select(s => s.FullName).ToList());
                return _customerNames;
            }
            private set
            {
                if (_customerNames != null && value != null && !_customerNames.Equals(value))
                {
                    _customerNames = value;
                    if (PropertyChanged != null)
                        RaisePropertyChanged("CustomerNames");
                }
            }
        }
        public static DataHelper Default
        {
            get
            {
                if (_defaultInstance == null)
                    _defaultInstance = new DataHelper();
                return _defaultInstance;
            }
        }
        public InventoryEntities Entity
        {
            get
            {
                if (_entity == null)
                    _entity = new InventoryEntities();
                return _entity;
            }
        }
        public ObservableCollection<Format> Formats
        {
            get
            {
                if (_formats == null)
                    _formats = new ObservableCollection<Format>(Entity.Formats.ToList());
                return _formats;
            }
            private set
            {
                if (_formats != null && value != null && !_formats.Equals(value))
                {
                    _formats = value;
                    if (PropertyChanged != null)
                        RaisePropertyChanged("Formats");
                }
            }
        }
        public ListCollectionView MovieCollection
        {
            get
            {
                if (_movieCollection == null)
                    _movieCollection = new ListCollectionView(Movies);
                return _movieCollection;
            }
            private set
            {
                if (_movieCollection != null && value != null && !_movieCollection.Equals(value))
                {
                    _movieCollection = value;
                    if (PropertyChanged != null)
                        RaisePropertyChanged("MovieCollection");
                }
            }
        }
        public ObservableCollection<Movie> Movies
        {
            get
            {
                if (_movies == null)
                    _movies = new ObservableCollection<Movie>(Entity.Movies.ToList());
                return _movies;
            }
            private set
            {
                if (_movies != null && value != null && !_movies.Equals(value))
                {
                    _movies = value;
                    if (PropertyChanged != null)
                        RaisePropertyChanged("Movies");
                }
            }
        }
        public ObservableCollection<SecurityQuestion> SecurityQuestions
        {
            get
            {
                if (_securityQuestions == null)
                    _securityQuestions = new ObservableCollection<SecurityQuestion>(Entity.SecurityQuestions.ToList());
                return _securityQuestions;
            }
            private set
            {
                if (_securityQuestions != null && value != null && !_securityQuestions.Equals(value))
                {
                    _securityQuestions = value;
                    if (PropertyChanged != null)
                        RaisePropertyChanged("SecurityQuestions");
                }
            }
        }
        public ObservableCollection<SecurityRole> SecurityRoles
        {
            get
            {
                if (_securityRoles == null)
                    _securityRoles = new ObservableCollection<SecurityRole>(Entity.SecurityRoles.ToList());
                return _securityRoles;
            }
            private set
            {
                if (_securityRoles != null && value != null && !_securityRoles.Equals(value))
                {
                    _securityRoles = value;
                    if (PropertyChanged != null)
                        RaisePropertyChanged("SecurityRoles");
                }
            }
        }
        public ObservableCollection<State> States
        {
            get
            {
                if (_states == null)
                    _states = new ObservableCollection<State>(Entity.States.ToList());
                return _states;
            }
            private set
            {
                if (_states != null && value != null && !_states.Equals(value))
                {
                    _states = value;
                    if (PropertyChanged != null)
                        RaisePropertyChanged("States");
                }
            }
        }
        public ObservableCollection<InventoryUser> Users
        {
            get
            {
                if (_users == null)
                    _users = new ObservableCollection<InventoryUser>(Entity.InventoryUsers.ToList());
                return _users;
            }
            private set
            {
                if (_users != null && value != null && !_users.Equals(value))
                {
                    _users = value;
                    if (PropertyChanged != null)
                        RaisePropertyChanged("Users");
                }
            }
        }
        #endregion
        #region Public Functions
        public void RefreshCheckOutHistories()
        {
            CheckOutHistories = null;
            var checkOutHistories = CheckOutHistories;
        }
        public void RefreshCustomers()
        {
            Customers = null;
            var customers = Customers;
        }
        public void RefreshFormats()
        {
            Formats = null;
            var formats = Formats;
        }
        public void RefreshMovies()
        {
            Movies = null;
            var movies = Movies;
        }
        public void RefreshSecurityQuestions()
        {
            SecurityQuestions = null;
            var securityQuestions = SecurityQuestions;
        }
        public void RefreshSecurityRoles()
        {
            SecurityRoles = null;
            var securityRoles = SecurityRoles;
        }
        public void RefreshStates()
        {
            States = null;
            var states = States;
        }
        public void RefreshUsers()
        {
            Users = null;
            var users = Users;
        }
        #endregion
    }
}