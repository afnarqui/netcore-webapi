using System;
using Afnarqui.Prueba.Transversal.Common;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Afnarqui.Prueba.Infraestructura.Data
{
    public class ConnectionFactory: IConnectionFactory
    {
        private readonly IConfiguration iconfiguration;

        public ConnectionFactory(IConfiguration configuration)
        {
            iconfiguration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                if (sqlConnection == null) return null;

                sqlConnection.ConnectionString = iconfiguration.GetConnectionString("PruebaConnection");
                sqlConnection.Open();
                return sqlConnection;
            }
        }
    }
}
