﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AskisMuseiDBEntities : DbContext
    {
        public AskisMuseiDBEntities()
            : base("name=AskisMuseiDBEntities")
        {
        }
        private static AskisMuseiDBEntities _content;
        public static AskisMuseiDBEntities GetContent()
        {
            if (_content == null)
                _content = new AskisMuseiDBEntities();
            return _content;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<HealStatus> HealStatus { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Quast> Quast { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<StatusID> StatusID { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}