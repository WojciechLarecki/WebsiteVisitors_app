using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteVisitorsAPI.Models
{
    public class VisitorsMappings : Profile
    {
        public VisitorsMappings()
        {
            CreateMap<Visitor, VisitorDTO>().ReverseMap();
        }
    }
}
