//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CircusWPF.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int Id { get; set; }
        public Nullable<int> IdRole { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Nullable<int> IdEmployee { get; set; }
    
        public virtual Roles Roles { get; set; }
    }
}