using Familia.Ecommerce.Transversal.Common;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Familia_Ecommerce.Infraestructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                if (sqlConnection == null)
                {
                    return null;
                }
                else
                {
                    sqlConnection.ConnectionString = _configuration.GetConnectionString("NortwindConnection");
                    sqlConnection.Open();
                    return sqlConnection;

                }
            }
        }
    }
}