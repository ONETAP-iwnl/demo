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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Tickets = new HashSet<Tickets>();
        }
    
        public int Id_Product { get; set; }
        public string NameProduct { get; set; }
        public string Description { get; set; }
        public Nullable<int> Price { get; set; }
        public string SizeBox { get; set; }
        public string WeightWithBox { get; set; }
        public string WeightWithoutBox { get; set; }
        public string NumberStandart { get; set; }
        public Nullable<System.DateTime> TimeOfCreate { get; set; }
        public Nullable<int> Cost { get; set; }
        public Nullable<int> NumberWorkshop { get; set; }
        public Nullable<int> CountEmployees { get; set; }
        public Nullable<int> Id_Materials { get; set; }
    
        public virtual Materials Materials { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
