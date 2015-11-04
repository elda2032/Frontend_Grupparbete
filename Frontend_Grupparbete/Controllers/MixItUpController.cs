using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frontend_Grupparbete.Controllers
{
    using System.Web.Mvc;

    public class MixItUpController : DatabaseController
    {
        public ActionResult Index()
        {
            return View(Database.Users);
        }
    }
}