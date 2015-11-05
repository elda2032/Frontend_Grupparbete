using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frontend_Grupparbete.Controllers
{
    using System.Data.Entity.Migrations;
    using System.Web.Mvc;

    using Frontend_Grupparbete.Models;

    public class LoginController : DatabaseController
    {
        public ActionResult Index()
        {
            Session["user"] = "Stefanbjerkell@gmail.com";
            return View();

        }

        public ActionResult Register()
        {
            return this.View();
        }

        public ActionResult Manage(string email)
        {
            var user = this.Database.Users.FirstOrDefault(u => u.Email == email);
            return this.View(user);
        }

        public PartialViewResult LoginPartial()
        {
            return this.PartialView("_login", Session["user"]);
        }

        [HttpPost]
        public void RemoveUser(string userEmail)
        {
            var user = Database.Users.FirstOrDefault(u => u.Email == userEmail);
            if (user != null)
            {
                Database.Users.Remove(user);
            }
        }

        [HttpPost]
        public void UpdateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            Database.Users.AddOrUpdate(user);
            Database.SaveChanges();
        }

        public void LoginUser(string userEmail, string password)
        {
            var user = Database.Users.FirstOrDefault(u => u.Email == userEmail);
            if (user == null)
            {
                throw new Exception("User not found!");
            }
            if (user.Password != password)
            {
                throw new Exception("Wrong Password");
            }

            Session["user"] = user.Email;
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}