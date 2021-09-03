using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteVisitorsAPI.Models.Interfaces
{
    public interface IVisitor
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime VisitTime { get; set; }
    }
}
