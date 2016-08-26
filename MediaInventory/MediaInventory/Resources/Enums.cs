using System.ComponentModel;

namespace MediaInventory.Resources
{
    public enum ForgotTypes
    {
        [Description("Login")]
        Login = 0,
        [Description("Password")]
        Password = 1
    }
    public enum InventoryTypes
    {
        None = 0,
        [Description("Movies")]
        Movies = 1,
        [Description("Music")]
        Music = 2,
        [Description("Books")]
        Books = 3,
        [Description("Customers")]
        Customers = 4,
        [Description("Recipes")]
        Recipes = 5
    }
    public enum MovieGroupHeaderTypes
    {
        None = 0,
        [Description("Check Status")]
        CheckStatus = 1,
        [Description("Owned")]
        Owned = 2,
        [Description("Wanted")]
        Wanted = 3,
        [Description("Format")]
        Format = 4
    }
    public enum PageTypes
    {
        None = 0,
        [Description("Search")]
        Search = 1,
        [Description("Add")]
        Add = 2,
        [Description("Edit")]
        Edit = 3
    }
    public enum PhoneTypes
    {
        [Description("Cell")]
        Cell = 0,
        [Description("Home")]
        Home = 1
    }
    public enum RecipeValuation
    {
        None = 0,
        [Description("Good")]
        Good = 1,
        [Description("Bad")]
        Bad = 2
    }
    public enum SecurityRoles
    {
        None = 0,
        [Description("Administrator")]
        Administrator = 1,
        [Description("Employee")]
        Employee = 2,
        [Description("Customer")]
        Customer = 3
    }
}