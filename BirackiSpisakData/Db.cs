using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BirackiSpisakDataManager
{
    static class Db
    {
        public static IDbConnection Conn(string naziv)
        {
            string connString = ConfigurationManager.ConnectionStrings[naziv].ConnectionString;
            IDbConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}
