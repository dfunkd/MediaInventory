using System.ComponentModel;

namespace MediaInventory.Data
{
    public class RecipeIngredient : INotifyPropertyChanged
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
        private decimal _quantity = 0;
        private Measurement _measurement;
        private Ingredient _ingredient;
        #endregion
        public RecipeIngredient(decimal quantity, Measurement measurement, Ingredient ingredient)
        {
            _quantity = quantity;
            _measurement = measurement;
            _ingredient = ingredient;
        }
        #region Public Properties
        public decimal Quantity
        {
            get { return _quantity; }
            private set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    if (PropertyChanged != null)
                        RaisePropertyChanged("Quantity");
                }
            }
        }
        public Measurement Measurement
        {
            get { return _measurement; }
            private set
            {
                if (_measurement != value)
                {
                    _measurement = value;
                    if (PropertyChanged != null)
                        RaisePropertyChanged("Measurement");
                }
            }
        }
        public Ingredient Ingredient
        {
            get { return _ingredient; }
            private set
            {
                if (_ingredient != value)
                {
                    _ingredient = value;
                    if (PropertyChanged != null)
                        RaisePropertyChanged("Ingredient");
                }
            }
        }
        #endregion
    }
}