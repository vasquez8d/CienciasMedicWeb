﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sol_CienciasMedicWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_A27E8E_norman8dEntities : DbContext
    {
        public DB_A27E8E_norman8dEntities()
            : base("name=DB_A27E8E_norman8dEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL01_INSCRIPCIONES> TBL01_INSCRIPCIONES { get; set; }
        public virtual DbSet<TBL02_CURSOS> TBL02_CURSOS { get; set; }
        public virtual DbSet<TBL03_INS_CURSO> TBL03_INS_CURSO { get; set; }
        public virtual DbSet<TBL04_MENSAJES> TBL04_MENSAJES { get; set; }
        public virtual DbSet<TBL06_MATRICULAS> TBL06_MATRICULAS { get; set; }
        public virtual DbSet<TBL07_PAQUETES> TBL07_PAQUETES { get; set; }
        public virtual DbSet<TBL08_TALLERES> TBL08_TALLERES { get; set; }
    }
}
