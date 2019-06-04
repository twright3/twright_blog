using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using twright_blog.Models;

namespace twright_blog.Controllers
{
    [RequireHttps]

    public class HomeController : Controller
    {
        //Landing Page
        public ActionResult Index()
        {
            return View();
        }


        //Change to Blog Gallary
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        //Add Blog Detail Page



        //Contact Me Page
        public ActionResult Contact()
        {
            EmailModel model = new EmailModel();
            return View(model);
        }


        //Add Login Page




        //Add Register Page


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var standardBodyMessage = $"<h3>You have received an email from {model.FromEmail}</h3>";
                    standardBodyMessage += $"<br /> {model.Body}";
                    var from = "MyBlog<travwright3@gmail.com>";


                    var email = new MailMessage(from, ConfigurationManager.AppSettings["emailto"])
                    {
                        Subject = model.Subject,
                        Body = standardBodyMessage,
                        IsBodyHtml = true
                    };

                    var svc = new PersonalEmail();
                    await svc.SendAsync(email);

                    return RedirectToAction("Index","BlogPosts");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.FromResult(0);
                }
            }
            return View(model);
        }

    }
}