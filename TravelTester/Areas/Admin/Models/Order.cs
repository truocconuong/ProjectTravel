using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TravelTester.Areas.Admin.Models
{
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int User_Id { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Tours")]
        public int Tours_Id { get; set; }
        public virtual Tours Tours { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}