using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace IntegrationAgentService.Repository
{
    public class SqlRepository
    {
        private readonly string _connectionString;

        public SqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task InsertAsync(string tableName, Dictionary<string, object> data)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var columns = string.Join(", ", data.Keys);
            var parameters = string.Join(", ", data.Keys.Select(k => "@" + k));
            var commandText = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

            using var command = new SqlCommand(commandText, connection);

            foreach (var kvp in data)
            {
                command.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
            }

            await command.ExecuteNonQueryAsync();
        }
    }
}