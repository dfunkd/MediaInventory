using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MediaInventory.Data
{
    public class ViewModel
    {
        InventoryEntities db = new InventoryEntities();
        public CollectionViewSource Movies { get; set; }
        private ObservableCollection<Movie> MoviesInternal { get; set; }
        public ViewModel()
        {
            MoviesInternal = new ObservableCollection<Movie>();
            Movies = new CollectionViewSource();
            Movies.Source = MoviesInternal;
            foreach (var movie in db.Movies)
                MoviesInternal.Add(movie);
        }
    }
}
