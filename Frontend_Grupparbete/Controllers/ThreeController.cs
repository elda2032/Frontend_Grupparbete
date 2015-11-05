using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frontend_Grupparbete.Controllers
{
    public class ThreeController : Controller
    {
        // GET: Three
        public ActionResult Index()
        {
            //http://www.sitepoint.com/building-earth-with-webgl-javascript/
            return View();
        }
    }
}