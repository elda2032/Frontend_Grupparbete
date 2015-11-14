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

            Session["user"] = user;
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return Json(new {success = true, message = "User is logged out"}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            object result;
            try
            {
                LoginUser(Email, Password);
                var loggedInUser = Session["user"] as User;
                if (loggedInUser == null)
                {
                    throw new Exception("Could not login user");
                }
                result = new { success = true, message = "User is logged in", id = loggedInUser.Id };
            }
            catch (Exception e)
            {
                result = new { success = false, message = e.Message };
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult TryGetLoggedInUser()
        {
            User user;
            object result;
            if (Session["user"] == null || (user = Session["user"] as User) == null)
            {
                result = new { success = false, message = "Sorry, you're not logged in!" };
            }
            else
            {
                result = new { success = true, email = user.Email, id = user.Id };
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}