using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteVisitorsAPI.Models.Interfaces
{
    interface IDataAccess
    {
        IEnumerable<T> LoadData<T, U>(string sqlQuery, U parameters);
        void SaveData<T>(string sqlQuery, T parameters);

    }
}
