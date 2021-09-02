using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WebsiteVisitorsAPI.Models.Interfaces;
using System.Data;
using Dapper;

namespace WebsiteVisitorsAPI.Models
{
    public class MySqlDataAccess : IDataAccess
    {
        private readonly IConfiguration _config;
        public string ConnectionType { get; set; } = "Default";
        
        public MySqlDataAccess(IConfiguration config)
        {
            _config = config;
        }
        public IEnumerable<T> LoadData<T, U>(string sqlQuery, U parameters)
        {
            IEnumerable<T> output;
            using (IDbConnection db = new MySqlConnection(_config.GetConnectionString(ConnectionType)))
            {
                output = db.Query<T>(sqlQuery, parameters);
                return output;
            }

        }

        public void SaveData<T>(string sqlQuery, T parameters)
        {
            using (IDbConnection db = new MySqlConnection(_config.GetConnectionString(ConnectionType)))
            {
                db.Execute(sqlQuery, parameters);
            }
        }
    }
}
