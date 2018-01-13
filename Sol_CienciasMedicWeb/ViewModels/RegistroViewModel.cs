using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sol_CienciasMedicWeb.Models;

namespace Sol_CienciasMedicWeb.ViewModels
{
    public class RegistroViewModel
    {
        public TBL01_INSCRIPCIONES ObjInscripciones { get; set; }
        public int CursoMatricula { get; set; }
        public bool Curso1 { get; set; }
        public bool Curso2 { get; set; }
        public bool Curso3 { get; set; }
    }
}