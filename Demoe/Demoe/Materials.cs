//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demoe
{
    using System;
    using System.Collections.Generic;
    
    public partial class Materials
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Materials()
        {
            this.Product = new HashSet<Product>();
        }
    
        public int Id_Materials { get; set; }
        public Nullable<int> id_TypeMaterial { get; set; }
        public string NameMaterial { get; set; }
        public Nullable<int> Id_Supplier { get; set; }
        public Nullable<int> AmmountBoxing { get; set; }
        public string Description { get; set; }
        public Nullable<int> Price { get; set; }
    
        public virtual Suppliers Suppliers { get; set; }
        public virtual TypeMaterial TypeMaterial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
