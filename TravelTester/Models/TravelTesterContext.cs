using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TravelTester.Models
{
    public class TravelTesterContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TravelTesterContext() : base("name=TravelTesterContext")
        {
        }

        public System.Data.Entity.DbSet<TravelTester.Areas.Admin.Models.Place> Places { get; set; }

        public System.Data.Entity.DbSet<TravelTester.Areas.Admin.Models.Transporter> Transporters { get; set; }

        public System.Data.Entity.DbSet<TravelTester.Areas.Admin.Models.Tours> Tours { get; set; }

        public System.Data.Entity.DbSet<TravelTester.Areas.Admin.Models.Review> Reviews { get; set; }

        public System.Data.Entity.DbSet<TravelTester.Areas.Admin.Models.User> User { get; set; }

        public System.Data.Entity.DbSet<TravelTester.Areas.Admin.Models.Order> Order { get; set; }
    }
}
