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
            // TODO: Format the list properly, in a similar way as data.txt
            //var userList = Database.Users.ToList();


            //string startFormat = @"{ ""data"": [ ";  
            //var userListJson = new JavaScriptSerializer().Serialize(userList);
            //var path = string.Format("{0}DataTableInsanity/userlist.txt", AppDomain.CurrentDomain.BaseDirectory);
            //System.IO.File.WriteAllText(path, userListJson);
            return View(Database.Users);
        }
    }
}