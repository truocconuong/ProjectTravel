using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTester.Areas.Admin.Models
{
    public class Transporter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Tours> tour { get; set; }
    }
}