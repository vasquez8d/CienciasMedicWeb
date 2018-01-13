using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sol_CienciasMedicWeb.Logic;
using Sol_CienciasMedicWeb.Models;

namespace Sol_CienciasMedicWeb.Controllers
{
    public class TalleresController : Controller
    {
        // GET: Talleres
        public ActionResult Index()
        {
            List<SelectListItem> listCursos = new List<SelectListItem>();

            var dataCursos = new TallerLogic().GetTalleres();

            foreach (var data in dataCursos)
            {
                listCursos.Add(new SelectListItem { Value = data.TALL_ID.ToString(), Text = data.TALL_NAME + "  -  Precio : " + data.TALL_PRICE });
            }

            ViewBag.dataTalleres = new SelectList(listCursos, "Value", "Text");

            return View();
        }

        public ActionResult _MatriculaTaller()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _MatriculaTaller(TBL06_MATRICULAS model)
        {
            model.MAT_TIPO = "TALLER";

            var result = "Error, por favor realize nuevamente la operación.";

            var tmpPathVoucher = string.Empty;
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = file.FileName;
                    tmpPathVoucher = Path.Combine(Server.MapPath("~/Content/vouchers_tmp/"), fileName);
                    file.SaveAs(tmpPathVoucher);
                }
            }
            else
            {
                result = "Error, no se cargo nungun voucher.";
            }

            var idMatricula = new CursosLogic().RegistrarMatricula(model, tmpPathVoucher);

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = "MATRICULA_VOUCHER_TALLER_" + idMatricula + ".jpg";
                    var path = Path.Combine(Server.MapPath("~/Content/vouchers/"), fileName);
                    file.SaveAs(path);
                    result = new CursosLogic().ActualizarRutaVoucher(idMatricula, path, model);
                }
            }
            else
            {
                result = "Error, no se cargo nungun voucher.";
            }

            result = result == "OK" ? "Fecilidades, tu matricula se registró con exito. Pronto nos comunicaremos contigo, cualquier duda enviar un mail a informes@cienciasmedic.com" : "Error";

            ViewBag.MatriculaResultTaller = result;

            return View("_Matricula");
        }

        public ActionResult _Matricula()
        {
            return View();
        }
    }
}