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

            // Temporary Login ===============//
            var user = Database.Users.First();//
            Session["user"] = user.Id;        //
            // ===============================//

            return View();

        }

        public ActionResult Register()
        {
            return this.View();
        }

        public ActionResult Manage(int id)
        {
            var user = this.Database.Users.FirstOrDefault(u => u.Id == id);
            return this.View(user);
        }

        public PartialViewResult LoginPartial()
        {
            int id;

            if (Session["user"] == null)
            {
                return this.PartialView("_login", null);
            }

            int.TryParse(Session["user"].ToString(), out id);
            var user = Database.Users.FirstOrDefault(u => u.Id == id);
            return PartialView("_login", user );
        }

        public JsonResult GetUser(int id)
        {
            var user  = this.Json(Database.Users.FirstOrDefault(u => u.Id == id), JsonRequestBehavior.AllowGet);
            return user;
        }

        public JsonResult GetUsers()
        {

            return this.Json(Database.Users, JsonRequestBehavior.AllowGet);
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
        public ActionResult UpdateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(400,"ModelState not Valid");
            }

            Database.Users.AddOrUpdate(user);
            Database.SaveChanges();

            return new HttpStatusCodeResult(201, "User updated");
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