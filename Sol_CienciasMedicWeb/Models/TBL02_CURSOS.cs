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
    
    public partial class TBL02_CURSOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL02_CURSOS()
        {
            this.TBL03_INS_CURSO = new HashSet<TBL03_INS_CURSO>();
        }
    
        public int CUR_ID { get; set; }
        public string CUR_NOMBRE { get; set; }
        public string CUR_DESC { get; set; }
        public Nullable<int> CUR_EST_REG { get; set; }
        public Nullable<System.DateTime> CUR_FEC_REG { get; set; }
        public string CUR_USU_REG { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL03_INS_CURSO> TBL03_INS_CURSO { get; set; }
    }
}
