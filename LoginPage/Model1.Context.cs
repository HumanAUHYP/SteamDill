﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SteamDill
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SteamDillEntities1 : DbContext
    {
        public SteamDillEntities1()
            : base("name=SteamDillEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<order_status> order_status { get; set; }
        public virtual DbSet<orders> orders { get; set; }
        public virtual DbSet<products> products { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tables> tables { get; set; }
        public virtual DbSet<user_types> user_types { get; set; }
        public virtual DbSet<users> users { get; set; }
    }
}
