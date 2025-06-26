using IntegrationAgentService.Models.AttachedDocumentSchema;

namespace IntegrationAgentService.Processors
{
    public interface IFileProcessor
    {
        AttachedDocument Process(string content, string filePath);
    }
}
