﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProgramModulesDevelopmentKursovik.ApplicationData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CompFirmEntities : DbContext
    {
        public CompFirmEntities()
            : base("name=CompFirmEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Carts> Carts { get; set; }
        public virtual DbSet<CatItems> CatItems { get; set; }
        public virtual DbSet<CatPrices> CatPrices { get; set; }
        public virtual DbSet<CatSections> CatSections { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<DoneStates> DoneStates { get; set; }
        public virtual DbSet<EdIzm> EdIzm { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersItems> OrdersItems { get; set; }
        public virtual DbSet<PaymentState> PaymentState { get; set; }
        public virtual DbSet<Producers> Producers { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
