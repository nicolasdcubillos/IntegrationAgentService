using Microsoft.Data.SqlClient;

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
            string commandText = string.Empty;
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var columns = string.Join(", ", data.Keys);
                var parameters = string.Join(", ", data.Keys.Select(k => "@" + k));
                commandText = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

                using var command = new SqlCommand(commandText, connection);

                foreach (var kvp in data)
                {
                    command.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
                }

                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                var paramInfo = string.Join(", ", data.Select(kvp => $"@{kvp.Key} = {kvp.Value ?? "NULL"}"));
                var errorMsg = $"[InsertAsync] Error al ejecutar:\nSQL: {commandText}\nParams: {paramInfo}\nTabla: {tableName}\nError: {ex.Message}";
                throw new Exception(errorMsg, ex);
            }
        }

        public async Task<List<Dictionary<string, object>>> SelectAsync(string tableName, string? whereClause = null)
        {
            string query = string.Empty;
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                query = $"SELECT * FROM {tableName}";
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
            catch (Exception ex)
            {
                var errorMsg = $"[SelectAsync] Error al ejecutar:\nSQL: {query}\nTabla: {tableName}\nError: {ex.Message}";
                throw new Exception(errorMsg, ex);
            }
        }

        public async Task UpdateAsync(string tableName, Dictionary<string, object> data, string whereClause)
        {
            string commandText = string.Empty;
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var setClause = string.Join(", ", data.Keys.Select(k => $"{k} = @{k}"));
                commandText = $"UPDATE {tableName} SET {setClause} WHERE {whereClause}";

                using var command = new SqlCommand(commandText, connection);

                foreach (var kvp in data)
                {
                    command.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
                }

                await command.ExecuteNonQueryAsync();
            } catch (Exception ex)
            {
                var paramInfo = string.Join(", ", data.Select(kvp => $"@{kvp.Key} = {kvp.Value ?? "NULL"}"));
                var errorMsg = $"[UpdateAsync] Error al ejecutar:\nSQL: {commandText}\nParams: {paramInfo}\nTabla: {tableName}\nError: {ex.Message}";
                throw new Exception(errorMsg, ex);
            }
        }

    }
}