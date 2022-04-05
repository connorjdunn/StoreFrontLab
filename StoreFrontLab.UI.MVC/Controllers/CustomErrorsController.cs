using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StoreFrontLab.UI.MVC.Controllers
{
    public class CustomErrorsController : Controller
    {
        // GET: CustomErrors
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Unresolved()
        {
            //This is our basic, "Default Custom Error" page. It is no different than any
            //of our other, custom Views.

            //To utilize this custom error page effectively, we could have logic that
            //redirects when something goes wrong (try/catch block) and sends the
            //user here instead. Ex: RedirectToAction("Unresolved", "CustomErrors")
            return View();
        }
    }
}