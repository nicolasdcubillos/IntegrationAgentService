using IntegrationAgentService.Models.AttachedDocumentSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IntegrationAgentService.Repository
{
    public class EntityTranslator : IEntityTranslator
    {
        private readonly Dictionary<string, Dictionary<string, string>> _fullMap;

        public EntityTranslator(string mappingFilePath)
        {
            var json = File.ReadAllText(mappingFilePath);

            _fullMap = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json)
                ?? throw new InvalidOperationException("Error leyendo el archivo de mapeo.");
            
        }
        public Dictionary<string, object> Translate(AttachedDocument attachedDocument, string table)
        {
            Dictionary<string, string> _map = _fullMap.TryGetValue(table, out var tableMap)
                ? tableMap
                : throw new InvalidOperationException($"No se encontró el apartado {table} en el archivo de mapeo.");

            var output = new Dictionary<string, object>();

            foreach (var kvp in _map)
            {
                var value = GetNestedPropertyValue(attachedDocument, kvp.Key);
                output[kvp.Value] = value ?? DBNull.Value;
            }

            return output;
        }

        private object? GetNestedPropertyValue(object? obj, string path)
        {
            if (obj == null || string.IsNullOrWhiteSpace(path))
                return null;

            var parts = path.Split('.');
            object? current = obj;

            foreach (var part in parts)
            {
                if (current == null) return null;

                var type = current.GetType();
                var prop = type.GetProperty(part, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (prop == null) return null;

                current = prop.GetValue(current);
            }

            return current;
        }
    }
}
