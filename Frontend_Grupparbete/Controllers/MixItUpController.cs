using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frontend_Grupparbete.Controllers
{
    using System.Web.Mvc;

    using Frontend_Grupparbete.Models;

    public class MixItUpController : DatabaseController
    {
        public ActionResult Index()
        {
            ViewBag.Nav = "Mix";
            return View(new MixItUpViewModel(Database.Users));
        }
    }
}