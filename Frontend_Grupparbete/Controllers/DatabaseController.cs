using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frontend_Grupparbete.Controllers
{
    using System.Web.Mvc;

    using Frontend_Grupparbete.Models;

    public class DatabaseController : Controller
    {
        public AppContext Database;

        public DatabaseController()
        {
            Database = new AppContext();
            if (Database.Users.Any())
            {
                return;
            }
            SeedDatabase();

        }

        public void SeedDatabase()
        {
            this.Database.Users.Add(
                new User()
                    {
                        Email = "Leelo@gmail.com",
                        FirstName = "Leelo",
                        LastName = "Dallas",
                        Income = 80,
                        Password = "magic",
                        Profession = "Supreme Beeing"
                    });
            this.Database.Users.Add(
                new User()
                    {
                        Email = "gmail@gmail.com",
                        FirstName = "Nisse",
                        LastName = "Lite",
                        Income = 2000,
                        Password = "magic",
                        Profession = "Manpower"
                    });
            this.Database.Users.Add(
                new User()
                    {
                        Email = "Stefanbjerkell@gmail.com",
                        FirstName = "Stefan",
                        LastName = "Bjerkell",
                        Income = 5000000,
                        Password = "magic",
                        Profession = "Professional Haxx0r"
                    });
            this.Database.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Database != null)
                {
                    this.Database.Dispose();
                    this.Database = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}