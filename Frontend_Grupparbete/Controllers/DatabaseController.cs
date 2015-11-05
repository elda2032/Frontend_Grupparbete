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
                        Email = "Lelo@gmail.com",
                        FirstName = "Lelo",
                        LastName = "Dalas",
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
            this.Database.Users.Add(AddUser("Dude@mailinator.com", "Henry", "Chuckle", 45000, "tragic", "Cheesecake Factory"));
            this.Database.Users.Add(AddUser("PizzaGuy@mailinator.com", "Frank", "Pastrami", 9, "tragic", "Pizza Hut"));
            this.Database.Users.Add(AddUser("Darth@vader.com", "Anakin", "Skywalker", 123456789, "sloth", "A Galaxy far, far away"));
            this.Database.SaveChanges();
        }

        protected User AddUser(string email, string firstName, string lastName, int income, string password,
            string profession)
        {
            User myUser = new User()
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Income = income,
                Password = password,
                Profession = profession
            };
            return myUser;
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