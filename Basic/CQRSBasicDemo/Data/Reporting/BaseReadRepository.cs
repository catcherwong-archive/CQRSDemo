namespace CQRSBasicDemo.Data.Reporting
{
    using System.Data.Common;
    using Microsoft.Data.Sqlite;
    using Microsoft.Extensions.Configuration;

    public class BaseReadRepository
    {
        protected readonly string _connStr;

        public BaseReadRepository(IConfiguration configuration)
        {
            _connStr = configuration.GetConnectionString("ReadConn");
        }


        protected DbConnection GetDbConnection()
        {
            return new SqliteConnection(_connStr);
        }

        protected DbConnection GetDbConnection(string connStr)
        {
            return new SqliteConnection(connStr);
        }
    }
}
