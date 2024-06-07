using Ado.Data.SqlServer;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using VBS_BackEnd.Models;

namespace VBS_BackEnd.DishRepository
{
    public partial class DishQuery
    {
        #region Properties
        private readonly SqlServerTable _table;
        #endregion

        #region Ctor
        public DishQuery(SqlServerTable table)
        {
            this._table = table;
        }
        #endregion

        #region Methods
        private List<Dish> ToList(SqlCommand sqlCommand)
        {
            var dt = _table.DbAccess.GetDataTable(sqlCommand);

            List<Dish> list = new List<Dish>();
            foreach (DataRow dataRow in dt.Rows)
            {
                Dish dish = new Dish()
                {
                    Id = (int)dataRow["Id"],
                    Name = (string)dataRow["Name"],
                    PhotoUrl = (string)dataRow["PhotoUrl"],
                    Requirements = (string)dataRow["Requirements"],
                    QuantityPer100GramAmount = (string)dataRow["QuantityPer100GramAmount"],
                    UnitInStock = (string)dataRow["UnitInStock"],
                    GroupId = (int)dataRow["GroupId"],
                    SubgroupId = (int)dataRow["SubgroupId"]
                };

                list.Add(dish);
            }
            return list;
        }

        public List<Dish> ToList(string sql)
        {
            return ToList(new SqlCommand(sql));
        }

        public int Count()
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "SELECT COUNT(*) FROM [Dish];";
                return Convert.ToInt32(_table.DbAccess.ExecuteScalar(sqlCommand));
            }
        }


        public List<Dish> All()
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "SELECT [Name],[PhotoUrl],[Requirements],[QuantityPer100GramAmount],[UnitInStock],[GroupId],[SubgroupId] FROM [Dish];";
                return ToList(sqlCommand);
            }
        }
        #endregion
    }
}
