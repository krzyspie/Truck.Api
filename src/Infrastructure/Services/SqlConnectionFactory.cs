﻿using Microsoft.Data.SqlClient;

namespace Infrastructure.Services
{
    public class SqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection Create()
        {
            return new SqlConnection(_connectionString);
        }

        public SqlConnection Create(string conectionString)
        {
            return new SqlConnection(conectionString);
        }

    }
}
