namespace IntegrationAgentService.Components.Processors
{
    public interface IFileProcessor
    {
        void Process(string content, string filePath);
    }
}
