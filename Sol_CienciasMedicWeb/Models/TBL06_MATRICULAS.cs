//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class TBL06_MATRICULAS
    {
        public int MATRI_ID { get; set; }
        public string MAT_NOMBRES { get; set; }
        public string MAT_APELLIDOS { get; set; }
        public string MAT_DNI { get; set; }
        public string MAT_CELL { get; set; }
        public string MAT_EMAIL { get; set; }
        public string MAT_RUTA_VOUCHER { get; set; }
        public Nullable<int> PAQ_ID { get; set; }
        public Nullable<int> MAT_EST_REG { get; set; }
        public Nullable<System.DateTime> MAT_FEC_REG { get; set; }
        public string MAT_USU_REG { get; set; }
        public string MAT_TIPO { get; set; }
    }
}