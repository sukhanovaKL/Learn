//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Learn
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductsHisoryBuy
    {
        public int Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> HistoryBuyId { get; set; }
        public Nullable<int> CountProduct { get; set; }
    
        public virtual HistiryBuy HistiryBuy { get; set; }
        public virtual Products Products { get; set; }
    }
}
