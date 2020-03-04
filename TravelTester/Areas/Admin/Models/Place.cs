using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTester.Areas.Admin.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Localtion { get; set; }
        public string Content { get; set; }
        public string Images { get; set; }
        public int starts { get; set; }
        public virtual ICollection<Tours> Tours { get; set; }
    }
}