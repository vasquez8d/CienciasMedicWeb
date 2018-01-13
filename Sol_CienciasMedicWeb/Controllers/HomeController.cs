using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sol_CienciasMedicWeb.Logic;
using Sol_CienciasMedicWeb.Models;
using Sol_CienciasMedicWeb.ViewModels;

namespace Sol_CienciasMedicWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly DB_A27E8E_norman8dEntities _context = new DB_A27E8E_norman8dEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _Registrar(RegistroViewModel model)
        {
            try
            {
                int newId;
                var data = (from u in _context.TBL01_INSCRIPCIONES orderby u.INS_ID descending select u).ToList();

                if (data.Count > 0)
                {
                    newId = data[0].INS_ID + 1;
                }
                else
                {
                    newId = 1;
                }
                
                List<string> cursos = new List<string>();

                if (model.Curso1)
                {
                    cursos.Add("1");
                }
                if (model.Curso2)
                {
                    cursos.Add("2");
                }
                if (model.Curso3)
                {
                    cursos.Add("3");
                }

                model.ObjInscripciones.INS_ID = newId;
                model.ObjInscripciones.INS_EST_REG = 1;
                model.ObjInscripciones.INS_USU_REG = "AVASQUEZ";
                model.ObjInscripciones.INS_FEC_REG = DateTime.Now;

                _context.TBL01_INSCRIPCIONES.Add(model.ObjInscripciones);
                _context.SaveChanges();

                foreach (var item in cursos)
                {
                    var objCurso = new TBL03_INS_CURSO
                    {
                        INS_ID = newId,
                        CUR_ID = int.Parse(item),
                        EST_REG = 1,
                        USU_REG = "AVASQUEZ",
                        FEC_INSC = DateTime.Now
                    };
                    _context.TBL03_INS_CURSO.Add(objCurso);
                    _context.SaveChanges();
                }

                var modelMensajes = new TBL04_MENSAJES
                {
                    MSJ_NOMBRES = model.ObjInscripciones.INS_NOMBRES,
                    MSJ_EMAIL = model.ObjInscripciones.INS_EMAIL + "cell:" + model.ObjInscripciones.INS_CELL,
                    MSJ_TITULO = "Nueva incripción para los cursos.",
                    MSJ_CONTENIDO = model.ObjInscripciones.INS_NOMBRES + " " +
                                    model.ObjInscripciones.INS_APELLIDOS + " DNI: " +
                                    model.ObjInscripciones.INS_DNI + ", se inscribio en los cursos de :"
                };
                
                foreach (var item in cursos)
                {
                    var dataCurso = (from u in _context.TBL02_CURSOS where u.CUR_ID == int.Parse(item) select u).ToList()[0];

                    modelMensajes.MSJ_CONTENIDO = modelMensajes.MSJ_CONTENIDO + dataCurso.CUR_DESC;
                }

                new EnvioMailLogic().EnviarMail(modelMensajes);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return View();
        }
    }
}