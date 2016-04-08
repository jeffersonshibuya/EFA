using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Efa.Infra.Data.Repository.ReadOnly
{
    public class RepositoryBaseReadOnly
    {
        public IDbConnection Connection
        {
            get
            {
                //return new MySqlConnection(ConfigurationManager.ConnectionStrings["EfaConnectionString"].ConnectionString);
                return new SqlConnection(ConfigurationManager.ConnectionStrings["EfaConnectionString"].ConnectionString);
            }
        } 
    }
}