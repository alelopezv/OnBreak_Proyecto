﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Onbreak.Datos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OnBreakEntities : DbContext
    {
        public OnBreakEntities()
            : base("name=OnBreakEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ActividadEmpresa> ActividadEmpresa { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<ModalidadServicio> ModalidadServicio { get; set; }
        public virtual DbSet<TipoEmpresa> TipoEmpresa { get; set; }
        public virtual DbSet<TipoEvento> TipoEvento { get; set; }
    }
}
