//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MediaInventory.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recipe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recipe()
        {
            this.Recipe2Ingredient2Measurement = new HashSet<Recipe2Ingredient2Measurement>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Directions { get; set; }
        public Nullable<bool> Valuation { get; set; }
        public string RecipeAcquiredFrom { get; set; }
        public Nullable<int> PrepTimeMinutes { get; set; }
        public Nullable<int> CookTimeMinutes { get; set; }
        public string Servings { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recipe2Ingredient2Measurement> Recipe2Ingredient2Measurement { get; set; }
    }
}
