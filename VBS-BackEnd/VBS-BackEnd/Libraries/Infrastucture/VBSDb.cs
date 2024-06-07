using Ado.Data.SqlServer;
using VBS.Db.RepositoryPacks;

namespace VBS.Db
{
    public partial class VBSDb : SqlServerDbAccess
    {
        #region Properties
        public DishRepositoryPack Dish { get; set; }
        #endregion

        #region Ctor
        public VBSDb(string cs) : base(new ConnectionStringBuilder() { ConnectionString = cs })
        {
            Dish = new DishRepositoryPack(this);
        }
    }
    #endregion
}
