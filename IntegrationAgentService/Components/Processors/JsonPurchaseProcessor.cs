using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace IntegrationAgentService.Components.Processors
{
    public class JsonPurchaseProcessor : IFileProcessor
    {
        private readonly ILogger _logger;

        public JsonPurchaseProcessor(ILogger logger)
        {
            _logger = logger;
        }

        public void Process(string content, string filePath)
        {
            try
            {
                using var doc = JsonDocument.Parse(content);

                // TODO: Map JSON to model and insert into DB
                _logger.LogInformation($"[JsonPurchaseProcessor] Successfully processed: {filePath}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[JsonPurchaseProcessor] Failed to process: {filePath}");
            }
        }
    }
}
