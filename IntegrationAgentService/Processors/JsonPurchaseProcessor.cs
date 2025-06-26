using IntegrationAgentService.Models.AttachedDocumentSchema;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace IntegrationAgentService.Processors
{
    public class JsonPurchaseProcessor : IFileProcessor
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _config;

        public JsonPurchaseProcessor(ILogger logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public AttachedDocument Process(string content, string filePath)
        {
            try
            {
                using var doc = JsonDocument.Parse(content);
                _logger.LogInformation($"[JsonPurchaseProcessor] Successfully processed: {filePath}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[JsonPurchaseProcessor] Failed to process: {filePath}");
            }

            throw new NotImplementedException("JSON processing not implemented yet.");
        }
    }
}
