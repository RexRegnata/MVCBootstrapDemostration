using Microsoft.AspNetCore.Mvc;
using MVCBootstrapDemo.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Net.Mail;
using System.Linq;

namespace MVCBootstrapDemo.Controllers
{
    public class QuestionController : Controller
    {
        public QuestionnaireModel questionnaire = JsonSerializer.Deserialize<QuestionnaireModel>(System.IO.File.ReadAllText
            (@"Models\JsonFile\propertyfile.json"));
        public ActionResult Index()
        {
            return View(questionnaire);
        }

        // POST: QuestionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IList<QuestionModel> questions)
        {    
            try
            {
                SmtpClient SmtpServer = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential("username", "password")
                };

                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("randomMail@gmail.com"),
                    Subject = "Questionnaire answers",
                    IsBodyHtml = true,
                    Body = JsonSerializer.Serialize(questions),
                };

                mail.To.Add(questionnaire.Email);

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {

            }

            return View(questionnaire);
        }
    }
}
