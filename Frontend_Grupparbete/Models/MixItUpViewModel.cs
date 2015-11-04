using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frontend_Grupparbete.Models
{
    using System.Web.WebSockets;

    public class MixItUpViewModel
    {
        public List<User> Users { get; set; }

        public List<string> Professions { get; set; }

        public MixItUpViewModel(IEnumerable<User> users)
        {
            Users = new List<User>();
            Professions = new List<string>();

            foreach (var user in users)
            {
                Users.Add(user);
                if (!Professions.Contains(user.Profession))
                {
                    Professions.Add(user.Profession);
                }

            }
        }

    }
}