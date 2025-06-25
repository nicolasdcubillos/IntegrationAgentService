// agregar referencias
using IntegrationAgentService.Components.Processors;

public class PurchaseInterface
{
    private readonly ILogger _logger;
    private readonly IConfiguration _config;
    private readonly string _inputFolder;
    private readonly string _processedFolder;
    private readonly Dictionary<string, IFileProcessor> _processors;

    public PurchaseInterface(ILogger logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;

        _inputFolder = _config["ServiceConfig:Interfaces:Purchase:WatchFolder"]
            ?? throw new ArgumentNullException("WatchFolder not found");

        _processedFolder = _config["ServiceConfig:Interfaces:Purchase:ProcessedFolder"]
            ?? throw new ArgumentNullException("ProcessedFolder not found");

        Directory.CreateDirectory(_inputFolder);
        Directory.CreateDirectory(_processedFolder);

        // registrar procesadores disponibles
        _processors = new Dictionary<string, IFileProcessor>(StringComparer.OrdinalIgnoreCase)
        {
            { ".xml", new XmlPurchaseProcessor(_logger, _config) },
            { ".json", new JsonPurchaseProcessor(_logger, _config) }
        };
    }

    public void Execute()
    {
        var files = Directory.GetFiles(_inputFolder, "*.*")
                             .Where(f => _processors.ContainsKey(Path.GetExtension(f)));

        foreach (var file in files)
        {
            try
            {
                _logger.LogInformation($"[PurchaseInterface] Processing {file}");

                var ext = Path.GetExtension(file).ToLowerInvariant();
                var content = File.ReadAllText(file);

                _processors[ext].Process(content, file);

                Thread.Sleep(500);

                var dest = Path.Combine(_processedFolder, Path.GetFileName(file));
                //File.Move(file, dest, true);

                _logger.LogInformation($"[PurchaseInterface] Moved to {dest}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[PurchaseInterface] Failed to process {file}");
            }
        }
    }
}
