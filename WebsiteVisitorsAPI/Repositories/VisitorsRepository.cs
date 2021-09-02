using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteVisitorsAPI.Models;
using WebsiteVisitorsAPI.Models.Interfaces;

namespace WebsiteVisitorsAPI.Repositories
{
    public class VisitorsRepository
    {
        private readonly IDataAccess _dataAccess;
        public VisitorsRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public IEnumerable<Visitor> GetAllVisitors()
        {
            string sqlQuery = "SELECT * FROM visitors;";
            IEnumerable<Visitor> visitors = _dataAccess.LoadData<Visitor>(sqlQuery);

            return visitors;
        }

        public void InsertVisitor(IVisitor visitor)
        {
            string sqlQuery = "INSERT INTO visitors VALUES (DEFAULT, @Name, @LastName, DEFAULT, @City);";
            _dataAccess.SaveData(sqlQuery, new { visitor.Name, visitor.LastName, visitor.City });
        }
    }
}
