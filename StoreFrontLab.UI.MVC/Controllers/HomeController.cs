using StoreFrontLab.UI.MVC.Models;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace StoreFrontLabIU.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

   //POST: Contact Form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel cvm)
        {
            //When a class has validation attributes, that validation 
            //should be checked before attempting to process any data.
            if (!ModelState.IsValid)
            {
                //Send them back to the form, and by passing the object
                //to the View, the form retains the entered information
                return View(cvm);
            }

            //The below only execute this code if the form (object) passes model validation.
            //Build the message -- what we will see when we receive the email
            string message = $"You have received an email from {cvm.Name}.<br />" +
                $"Subject: {cvm.Subject}" +
                $"Mesage: {cvm.Message}<br />" +
                $"Please respond to {cvm.Email} with your reply.";

            //MailMessage - System.Net.Mail
            MailMessage mm = new MailMessage(

                //FROM
                ConfigurationManager.AppSettings["EmailUser"].ToString(),

                //TO
                ConfigurationManager.AppSettings["EmailTo"].ToString(),

                //SUBJECT
                cvm.Subject,

                //BODY
                message

                );

            //MailMessage Properties
            //Allow HTML formatting in the email (message has HTML in it)
            mm.IsBodyHtml = true;

            //If you want to mark these emails as high priorty...
            mm.Priority = MailPriority.High;

            //Respond to the senser's email instead of our own email user
            mm.ReplyToList.Add(cvm.Email);

            //SMTPClient - This is referring to the information from the HOST (SmarterASP.net).
            //This allows the email to actually be sent

            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["EmailClient"].ToString());

            //Client credentials (SmartASP.net requires your user name and password)
            client.Credentials = new NetworkCredential(

                //User
                ConfigurationManager.AppSettings["EmailUser"].ToString(),

                //Password
                ConfigurationManager.AppSettings["EmailPass"].ToString()

                );

            //It is possible that the mailserver is down or we might have some
            //issues with our configuration. So, we should encapsulate our code
            //in a try/catch

            try
            {
                //Attempt to send the email
                client.Send(mm);
            }
            catch (Exception ex)
            {
                //Return the View with the entire message so users can copy and paste
                //for later.
                ViewBag.CustomerMessage = $"We're sorry, but your request could not be" +
                    $"completed at this time. Please try again later. <br />" +
                    $"Error Message: {ex.StackTrace}";

                return View(cvm);
            }

            //If all goes well, return a View that displays a confirmation to the end user.
            return View("EmailConfirmation", cvm);

        }


        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your about page.";

            return View();
        }

        [HttpGet]
        public ActionResult Products()
        {
            return View();
        }
    }
}
