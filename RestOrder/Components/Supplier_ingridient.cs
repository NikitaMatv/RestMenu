//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestOrder.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supplier_ingridient
    {
        public Nullable<int> IngridientID { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public int ID { get; set; }
    
        public virtual Ingridient Ingridient { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
