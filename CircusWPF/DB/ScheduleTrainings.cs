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
    
    public partial class ScheduleTrainings
    {
        public int Id { get; set; }
        public Nullable<int> IdAnimal { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
    
        public virtual Animals Animals { get; set; }
    }
}
