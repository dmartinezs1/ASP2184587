﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP2184587.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class inventarioEntities : DbContext
    {
        public inventarioEntities()
            : base("name=inventarioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cliente> clientes { get; set; }
        public virtual DbSet<compra> compras { get; set; }
        public virtual DbSet<producto> productoes { get; set; }
        public virtual DbSet<producto_compra> producto_compra { get; set; }
        public virtual DbSet<proveedor> proveedors { get; set; }
        public virtual DbSet<usuario> usuarios { get; set; }
    }
}
