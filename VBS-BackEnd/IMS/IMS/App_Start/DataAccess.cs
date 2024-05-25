using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.App_Start
{
    public class DataAccess
    {
        private SqlConnection _connection;

        public DataAccess(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }
    }
}