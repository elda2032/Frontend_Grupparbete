using System.Collections.Generic;
using System.Linq;

namespace Frontend_Grupparbete.Models
{
    using System.Web.Mvc;

    public class MixItUpViewModel
    {
        public List<User> Users { get; set; }

        public List<SelectListItem> Professions { get; set; }

        public MixItUpViewModel(IEnumerable<User> users)
        {
            Users = new List<User>();
            Professions = new List<SelectListItem>();
            Professions.Add(new SelectListItem() { Text = "Show All", Value = "All" });
            foreach (var user in users)
            {
                Users.Add(user);
                var found = false;
                foreach (var item in this.Professions.Where(item => item.Value == user.Profession))
                {
                    found = true;
                }

                if (!found && !string.IsNullOrEmpty(user.Profession)) Professions.Add(new SelectListItem() { Text = user.Profession, Value = user.Profession.Split(' ')[0] });
            }

        }
    }
}