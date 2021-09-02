using System.Collections.Generic;
using WebsiteVisitorsAPI.Models;
using WebsiteVisitorsAPI.Models.Interfaces;

namespace WebsiteVisitorsAPI.Repositories.Interfaces
{
    public interface IVisitorsRepository
    {
        IEnumerable<Visitor> SelectAllVisitors();
        void InsertVisitor(IVisitor visitor);
    }
}