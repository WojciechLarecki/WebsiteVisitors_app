using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteVisitorsAPI.Models.Interfaces;

namespace WebsiteVisitorsAPI.Models
{
    public class Visitor : IVisitor
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime VisitTime { get; set; }
    }
}
