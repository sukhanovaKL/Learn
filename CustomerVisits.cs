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
    
    public partial class CustomerVisits
    {
        public int Id { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<System.DateTime> DateVisit { get; set; }
        public Nullable<int> ServiceId { get; set; }
        public string Comment { get; set; }
        public Nullable<int> OtherPhotoId { get; set; }
    
        public virtual Customers Customers { get; set; }
        public virtual OtherPhotos OtherPhotos { get; set; }
        public virtual Services Services { get; set; }
    }
}
