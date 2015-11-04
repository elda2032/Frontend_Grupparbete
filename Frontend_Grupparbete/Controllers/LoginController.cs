using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frontend_Grupparbete.Controllers
{
    using System.Web.Mvc;

    using Frontend_Grupparbete.Models;

    public class LoginController : DatabaseController
    {
        public ActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public void AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            Database.Users.Add(user);
            Database.SaveChanges();
        }
    }
}