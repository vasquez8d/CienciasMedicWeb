using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using Sol_CienciasMedicWeb.Models;

namespace Sol_CienciasMedicWeb.Logic
{
    public class EnvioMailLogic
    {
        private DB_A27E8E_norman8dEntities _context = new DB_A27E8E_norman8dEntities();

        public string EnviarMail(TBL04_MENSAJES modelMensajes, string tmpPathVoucher = " ")
        {
            const string txtFrom = "informes@cienciasmedic.com";
            const string txtPass = "informes@123";

            var txtTo = ConfigurationManager.AppSettings["mailTo"];

            const string txtMailServer = "mail.cienciasmedic.com";

            string resultado;

            using (var m = new MailMessage())
            {
                var sc = new SmtpClient();
                m.From = new MailAddress(txtFrom);
                m.To.Add(txtTo);
                m.Subject = "Nuevo mensaje a cienciasmedic.com";
                m.Body = "Mail enviado por : " + modelMensajes.MSJ_EMAIL + "\n\r" +
                         "Nombres : " + modelMensajes.MSJ_NOMBRES + "\n\r" +
                         "Cuerpo del Mensaje : " + modelMensajes.MSJ_CONTENIDO;

                if (!string.IsNullOrWhiteSpace(tmpPathVoucher))
                {
                    var inline = new Attachment(tmpPathVoucher);
                    inline.ContentDisposition.Inline = true;
                    inline.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                    inline.ContentType.MediaType = "image/png";
                    inline.ContentType.Name = Path.GetFileName(tmpPathVoucher);
                    m.Attachments.Add(inline);
                }

                sc.Host = txtMailServer;
                const string str1 = "gmail.com";
                var str2 = txtFrom.ToLower();
                if (str2.Contains(str1))
                {
                    try
                    {
                        sc.Port = 587;
                        sc.Credentials = new System.Net.NetworkCredential(txtFrom, txtPass);
                        sc.EnableSsl = true;
                        sc.Send(m);
                        resultado = "Email Send successfully";
                    }
                    catch (Exception ex)
                    {
                        resultado = "error_al enviar";
                        Console.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    try
                    {
                        sc.Port = 25;
                        sc.Credentials = new System.Net.NetworkCredential(txtFrom, txtPass);
                        sc.EnableSsl = false;
                        sc.Send(m);
                        resultado = "Email Send successfully";
                    }
                    catch (Exception ex)
                    {
                        resultado = "error_al enviar";
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(tmpPathVoucher))
            {
                File.Delete(tmpPathVoucher);
            }
            return resultado;
        }
    }
}