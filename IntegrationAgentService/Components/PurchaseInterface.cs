using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading;

namespace IntegrationAgentService.Components
{
    public class PurchaseInterface
    {
        private readonly ILogger _logger;
        private readonly string _inputFolder;
        private readonly string _processedFolder;

        public PurchaseInterface(ILogger logger, IConfiguration config)
        {
            _logger = logger;

            _inputFolder = config["ServiceConfig:Interfaces:Purchase:WatchFolder"]
                ?? throw new ArgumentNullException("WatchFolder not found in configuration");

            _processedFolder = config["ServiceConfig:Interfaces:Purchase:ProcessedFolder"]
                ?? throw new ArgumentNullException("ProcessedFolder not found in configuration");

            Directory.CreateDirectory(_inputFolder);
            Directory.CreateDirectory(_processedFolder);
        }

        public void Execute()
        {
            var files = Directory.GetFiles(_inputFolder, "*.txt");

            foreach (var file in files)
            {
                try
                {
                    _logger.LogInformation($"[PurchaseInterface] Processing {file}");

                    // 🔁 Simulate FoxPro PRG call
                    Thread.Sleep(500);

                    var dest = Path.Combine(_processedFolder, Path.GetFileName(file));
                    File.Move(file, dest, true);

                    _logger.LogInformation($"[PurchaseInterface] Moved to {dest}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"[PurchaseInterface] Failed to process {file}");
                }
            }
        }
    }
}
