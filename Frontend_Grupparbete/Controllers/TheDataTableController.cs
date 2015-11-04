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
            string userListJson = new JavaScriptSerializer().Serialize(Database.Users.ToList());
            //System.IO.File.WriteAllText(@"C:\userlist.txt", userListJson);
            return View(Database.Users);
        }
        
    }
}