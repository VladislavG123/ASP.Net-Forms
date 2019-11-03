using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace LandingWithForm.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SendToEmail(string name, string email, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.mail.ru");

                mail.From = new MailAddress("gvo_step2018@mail.ru");
                mail.To.Add(email);
                mail.Subject = $"User: {name}, Subject: {subject}";
                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("gvo_step2018@mail.ru", "password");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return View("index");
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return View("Error");
            }
        }
    }
}
