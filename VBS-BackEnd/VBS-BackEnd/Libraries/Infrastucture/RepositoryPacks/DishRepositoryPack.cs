using Ado.Data.SqlServer;
using VBS_BackEnd.DishRepository;
using VBS_BackEnd.Libraries.DishRepository;

namespace VBS.Db.RepositoryPacks
{
    public partial class DishRepositoryPack : SqlServerTable
    {
        #region Properties
        public DishQuery Query { get; set; }

        #endregion

        #region Ctor
        public DishRepositoryPack(SqlServerDbAccess dbAccess) : base(dbAccess)
        {
            Query = new DishQuery(this);
        }
        #endregion
    }
}
