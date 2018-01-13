using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Sol_CienciasMedicWeb.Models;
using Sol_CienciasMedicWeb.ViewModels;

namespace Sol_CienciasMedicWeb.Logic
{
    public class CursosLogic
    {
        private readonly DB_A27E8E_norman8dEntities _context = new DB_A27E8E_norman8dEntities();

        public List<TBL07_PAQUETES> GetCursosMatricula()
        {
            List<TBL07_PAQUETES> listaPaquetes = (from u in _context.TBL07_PAQUETES select u).ToList();
            return listaPaquetes;
        }

        public int RegistrarMatricula(TBL06_MATRICULAS model, string tmpPathVoucher)
        {
            try
            {
                int newId;

                var data = (from u in _context.TBL06_MATRICULAS orderby u.MATRI_ID descending select u).ToList();

                if (data.Count > 0)
                {
                    newId = data[0].MATRI_ID + 1;
                }
                else
                {
                    newId = 1;
                }

                model.MATRI_ID = newId;
                model.MAT_EST_REG = 1;
                model.MAT_USU_REG = "AVASQUEZ";
                model.MAT_FEC_REG = DateTime.Now;

                _context.TBL06_MATRICULAS.Add(model);
                _context.SaveChanges();

                var modelMensajes = new TBL04_MENSAJES
                {
                    MSJ_NOMBRES = model.MAT_NOMBRES,
                    MSJ_EMAIL = model.MAT_EMAIL + "cell:" + model.MAT_CELL,
                    MSJ_TITULO = "Nueva incripción para los cursos.",
                    MSJ_CONTENIDO = model.MAT_NOMBRES + " " +
                                    model.MAT_APELLIDOS + " DNI: " +
                                    model.MAT_DNI + ", se matriculo para : "
                };

                if (model.MAT_TIPO == "TALLER")
                {
                    var dataTaller = (from u in _context.TBL08_TALLERES where u.TALL_ID == model.PAQ_ID select u).ToList()[0];

                    modelMensajes.MSJ_CONTENIDO = "El taller de : " +modelMensajes.MSJ_CONTENIDO + dataTaller.TALL_NAME;
                }
                else
                {
                    var dataPaquete = (from u in _context.TBL07_PAQUETES where u.PAQ_ID == model.PAQ_ID select u).ToList()[0];

                    modelMensajes.MSJ_CONTENIDO = "El paquete de : " + modelMensajes.MSJ_CONTENIDO + dataPaquete.PAQ_NOMBRE;
                }

                new EnvioMailLogic().EnviarMail(modelMensajes, tmpPathVoucher);

                return newId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return 0;
        }

        public string ActualizarRutaVoucher(int idMatricula, string path, TBL06_MATRICULAS model)
        {
            string result;
            try
            {
                model.MAT_RUTA_VOUCHER = path;
                _context.TBL06_MATRICULAS.AddOrUpdate(model);
                _context.SaveChanges();

                result = "OK";
            }
            catch
            {
                result = "ERROR";
            }
            return result;
        }
    }
}