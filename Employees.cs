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
    
    public partial class Employees
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string PassportNumber { get; set; }
        public string PassportSeria { get; set; }
        public Nullable<int> KodPodrazdelenia { get; set; }
        public Nullable<double> Coefficient { get; set; }
        public Nullable<System.DateTime> DateBirthDay { get; set; }
        public Nullable<int> EmployeeCategoryId { get; set; }
    
        public virtual EmployeeCategories EmployeeCategories { get; set; }
    }
}
