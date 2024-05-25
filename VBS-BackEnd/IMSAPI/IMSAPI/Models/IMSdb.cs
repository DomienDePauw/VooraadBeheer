using System.Data.SqlClient;
using InventoryManagementSystem.Db.RepositoryPacks;
using System.Data.Common;

namespace InventoryManagementSystem.Db
{
    public partial class IMSdb //: SqlServerDbAccess wtf moet er hier???
    {
        //#region Properties
        //public DriverRepositoryPack Driver { get; set; }
        //public RaceRepositoryPack Race { get; set; }
        //public Race_DriverRepositoryPack Race_Driver { get; set; }
        //public UserRepositoryPack User { get; set; }
        //public UserTypeRepositoryPack UserType { get; set; }
        //public BetRepositoryPack Bet { get; set; }
        //public CarsRepositoryPack Cars { get; set; }
        //#endregion

        //#region Ctor
        //public IMSdb(string cs) : base(new ConnectionStringBuilder() { ConnectionString = cs })
        //{
        //    Driver = new DriverRepositoryPack(this);
        //    Race = new RaceRepositoryPack(this);
        //    Race_Driver = new Race_DriverRepositoryPack(this);
        //    User = new UserRepositoryPack(this);
        //    UserType = new UserTypeRepositoryPack(this);
        //    Bet = new BetRepositoryPack(this);
        //    Race = new RaceRepositoryPack(this);
        //    Cars = new CarsRepositoryPack(this);
        //}
    }
    #endregion
}
