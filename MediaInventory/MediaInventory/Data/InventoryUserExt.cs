using MediaInventory.Resources;

namespace MediaInventory.Data
{
    public partial class InventoryUser
    {
        public string DecryptedCell
        {
            get
            {
                var cell = string.Empty;
                if (CellPhone != null)
                    cell = Helpers.Decrypt(CellPhone);
                return cell;
            }
        }
        public string DecryptedEmail
        {
            get
            {
                var email = string.Empty;
                if (Email != null)
                    email = Helpers.Decrypt(Email);
                return email;
            }
        }
        public string DecryptedLogin
        {
            get
            {
                var login = string.Empty;
                if (Login != null)
                    login = Helpers.Decrypt(Login);
                return login;
            }
        }
        public string DecryptedPassword
        {
            get
            {
                var password = string.Empty;
                if (Password != null)
                    password = Helpers.Decrypt(Password);
                return password;
            }
        }
    }
}