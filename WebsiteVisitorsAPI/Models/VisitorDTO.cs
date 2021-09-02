using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebsiteVisitorsAPI.Models.Interfaces;

namespace WebsiteVisitorsAPI.Models
{
    public class VisitorDTO : IVisitor
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string City { get; set; }
    }
}
