using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTester.Areas.Admin.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostCode { get; set; }
        public string CardName { get; set; }
        public int CardNumber { get; set; }
        public string SecurityCode { get; set; }
        public string ExpiraDateMonth { get; set; }
        public string ExpiraDateYear { get; set; }
        public DateTime CreatedAt {get;set;}
        public virtual ICollection<Order> Orders { get; set; }
    }
}