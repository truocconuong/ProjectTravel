using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TravelTester.Areas.Admin.Models
{
    public class Tours
    {
        public int Id { get; set; }
        [ForeignKey("Place")]
        public int Place_Id { get; set; }
        public virtual Place Place { get; set; }
        [ForeignKey("Transporter")]
        public int Transporter_Id { get; set; }
        public virtual Transporter Transporter { get; set; }
        public string Titile { get; set; }
        public string Content { get; set; }
        public string Images { get; set; }
        public string Description { get; set; }
        public string Quantity_people { get; set; }
        public double Price { get; set; }
        public DateTime Time_start { get; set; }
        public DateTime Time_end { get; set; }
        public double Duration { get; set; }
        public DateTime Time_departure { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

    }
}