using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TravelTester.Areas.Admin.Models
{
    public class Review
    {
        public int Id { get; set; }
        [ForeignKey("Tour")]
        public int Tour_Id { get; set; }
        public virtual Tours Tour { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public DateTime Created_At { get; set; }


    }
}