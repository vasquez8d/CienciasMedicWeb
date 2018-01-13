using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sol_CienciasMedicWeb.Logic;
using Sol_CienciasMedicWeb.Models;

namespace Sol_CienciasMedicWeb.Controllers
{
    public class ContactoController : Controller
    {
        private readonly DB_A27E8E_norman8dEntities _context = new DB_A27E8E_norman8dEntities();

        // GET: Contacto
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.TBL04_MENSAJES model)
        {
            try
            {
                var listNewId = (from u in _context.TBL04_MENSAJES orderby u.MSJ_ID descending select u);
                var newId = 0;

                if (listNewId.Any())
                {
                    newId = listNewId.ToList()[0].MSJ_ID + 1;
                }
                else
                {
                    newId = 1;
                }

                model.MSJ_ID = newId;
                model.MSJ_EST_REG = 1;
                model.MSJ_USU_REG = "AVASQUEZ";
                model.MSJ_FEC_REG = DateTime.Now;

                _context.TBL04_MENSAJES.Add(model);
                _context.SaveChanges();

                new EnvioMailLogic().EnviarMail(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return RedirectToAction("Index");
            }
        }
    }
}