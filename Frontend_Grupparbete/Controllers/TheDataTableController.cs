using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Frontend_Grupparbete.Models;

namespace Frontend_Grupparbete.Controllers
{
    public class TheDataTableController : DatabaseController
    {
        // GET: DataTable get.rekt();
        public ActionResult Index()
        {
            return View(Database.Users);
        }
    }
}