﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace BE
{

    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    

    public partial class BDEntities : DbContext
    {
        public BDEntities()
            : base("name=BDEntities")
        {

        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    

        public virtual DbSet<almacen> almacen { get; set; }

        public virtual DbSet<categoria> categoria { get; set; }

        public virtual DbSet<direccion> direccion { get; set; }

        public virtual DbSet<inventario> inventario { get; set; }

        public virtual DbSet<local> local { get; set; }

        public virtual DbSet<marca> marca { get; set; }

        public virtual DbSet<movimiento> movimiento { get; set; }

        public virtual DbSet<movimientodet> movimientodet { get; set; }

        public virtual DbSet<persona> persona { get; set; }
        public virtual DbSet<rubro> rubro { get; set; }
        public virtual DbSet<serie> serie { get; set; }

        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<articulo> articulo { get; set; }
        public virtual DbSet<articulodet> articulodet { get; set; }

        public virtual DbSet<caracteristica> caracteristica { get; set; }
    }

}

