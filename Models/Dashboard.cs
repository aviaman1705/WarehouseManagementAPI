using MvcTaskManager.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTaskManager.Models
{
    public class Dashboard
    {
        private ApplicationDbContext db;

        public Dashboard(ApplicationDbContext db)
        {
            this.db = db;
            this.ProductsCount = db.Products.Count();
            this.LocationsCount = db.Locations.Count();
        }

        public int ProductsCount { get; set; }
        public int LocationsCount { get; set; }
    }
}
