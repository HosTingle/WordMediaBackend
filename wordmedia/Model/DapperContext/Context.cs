using System.Data;
using System.Data.SqlClient;
namespace wordmedia.Model.DapperContext
{
    public class Context
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("connection");
        }
        public IDbConnection CreatConnection() => new SqlConnection(_connectionString);
    }
}
