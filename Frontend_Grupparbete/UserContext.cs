using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frontend_Grupparbete
{
    using System.Data.Entity;

    using Frontend_Grupparbete.Models;

    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}