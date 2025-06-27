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

        public async Task<List<Dictionary<string, object>>> SelectAsync(string tableName, string? whereClause = null)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = $"SELECT * FROM {tableName}";
            if (!string.IsNullOrWhiteSpace(whereClause))
                query += $" WHERE {whereClause}";

            using var command = new SqlCommand(query, connection);

            using var reader = await command.ExecuteReaderAsync();

            var results = new List<Dictionary<string, object>>();

            while (await reader.ReadAsync())
            {
                var row = new Dictionary<string, object>();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[reader.GetName(i)] = reader.IsDBNull(i) ? null! : reader.GetValue(i);
                }

                results.Add(row);
            }

            return results;
        }

        public async Task UpdateAsync(string tableName, Dictionary<string, object> data, string whereClause)
        {
            if (data == null || data.Count == 0)
                throw new ArgumentException("El diccionario de datos no puede estar vacío.", nameof(data));

            if (string.IsNullOrWhiteSpace(whereClause))
                throw new ArgumentException("Debe proporcionar una cláusula WHERE para evitar actualizar todo.", nameof(whereClause));

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var setClause = string.Join(", ", data.Keys.Select(k => $"{k} = @{k}"));
            var commandText = $"UPDATE {tableName} SET {setClause} WHERE {whereClause}";

            using var command = new SqlCommand(commandText, connection);

            foreach (var kvp in data)
            {
                command.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
            }

            await command.ExecuteNonQueryAsync();
        }

    }
}