//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProgramModulesDevelopmentKursovik.ApplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class CatItems
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CatItems()
        {
            this.Carts = new HashSet<Carts>();
            this.CatPrices = new HashSet<CatPrices>();
            this.OrdersItems = new HashSet<OrdersItems>();
        }
    
        public int id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public int edizm_id { get; set; }
        public int catsection_id { get; set; }
        public int country_id { get; set; }
        public int producer_id { get; set; }
        public int supplier_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Carts> Carts { get; set; }
        public virtual CatSections CatSections { get; set; }
        public virtual Countries Countries { get; set; }
        public virtual EdIzm EdIzm { get; set; }
        public virtual Producers Producers { get; set; }
        public virtual Suppliers Suppliers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CatPrices> CatPrices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersItems> OrdersItems { get; set; }
    }
}
