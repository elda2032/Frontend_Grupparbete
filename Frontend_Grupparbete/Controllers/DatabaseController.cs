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
            //Fast track to dropping the table for a new seed
            //Database.Database.ExecuteSqlCommand("delete from users");
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
                        Profession = "McDonalds"
                    });
            this.Database.Users.Add(
                new User()
                    {
                        Email = "Nisse@Apple.com",
                        FirstName = "Nisse",
                        LastName = "Tomte",
                        Income = 2000,
                        Password = "magic",
                        Profession = "Apple"
                    });
            this.Database.Users.Add(
                new User()
                    {
                        Email = "Stefanbjerkell@blizzard.com.com",
                        FirstName = "Stefan",
                        LastName = "Bjerkell",
                        Income = 5000000,
                        Password = "magic",
                        Profession = "Blizzard"
                    });
            this.Database.Users.Add(AddUser("Dude@mailinator.com", "Henry", "Chuckle", 45000, "tragic", "Cheesecake Consumer"));
            this.Database.Users.Add(AddUser("PizzaGuy@mailinator.com", "Frank", "Pastrami", 9, "tragic", "Pizza Delivery Guy"));
            this.Database.Users.Add(AddUser("Darth@vader.com", "Anakin", "Skywalker", 123456789, "sloth", "Force Ghost?"));
            this.Database.Users.Add(AddUser("Probably@undoubtably.net", "Popcorn", "Thrower", 49204, "popcorn", "Movie Connoisseur"));
            this.Database.Users.Add(AddUser("DerekMiller@contosouniversity.com", "Derek", "Miller", -350, "mydogsname", "Student"));
            this.Database.Users.Add(AddUser("StephenCurry@contosouniversity.com", "Stephen", "Curry", 500, "gswarrior", "Student"));
            this.Database.Users.Add(AddUser("BörkBörk@swedishchef.com", "Köksmästaren", "Börksson", 150000, "börk", "Chef"));
            this.Database.Users.Add(AddUser("JetLi@jetli.com", "李連杰", "李連杰", 90000, "jetli", "Martial Artist"));
            this.Database.Users.Add(AddUser("polina@polinagagarina.com", "Полина", "Гагарина", 190000, "polina", "Singer"));
            this.Database.Users.Add(AddUser("jaesuk@runningman.com", "유", "재석", 256000, "runningman", "Actor"));
            this.Database.Users.Add(AddUser("atsushi@bucktick.com", "敦司", "櫻井", 45000, "bucktick", "Singer"));
            
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