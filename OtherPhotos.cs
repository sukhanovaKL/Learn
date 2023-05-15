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
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Windows.Media.Imaging;

    public partial class OtherPhotos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OtherPhotos()
        {
            this.CustomerVisits1 = new HashSet<CustomerVisits>();
            this.Products = new HashSet<Products>();
            this.Services = new HashSet<Services>();
        }
    
        public int Id { get; set; }
        public string Photo { get; set; }
        public Nullable<int> IdServise { get; set; }
        public Nullable<int> ProductsId { get; set; }
        public Nullable<int> ServicesId { get; set; }
        public Nullable<int> CustomerVisits { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerVisits> CustomerVisits1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Products> Products { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Services> Services { get; set; }

        [NotMapped]
        public BitmapImage PhotoFromResources => !string.IsNullOrEmpty(Photo) ? new BitmapImage(new Uri("C:/Users/79393/source/repos/Learn/Photos/" + Photo)) : new BitmapImage(new Uri("C:/Users/79393/source/repos/Learn/Photos/school_logo.png"));
    }
}
