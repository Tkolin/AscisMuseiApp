//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AscisMuseiApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quast
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> StatusID { get; set; }
    
        public virtual StatusID StatusID1 { get; set; }
        public virtual User User { get; set; }
    }
}
