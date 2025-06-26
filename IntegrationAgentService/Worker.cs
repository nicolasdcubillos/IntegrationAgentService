public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IConfiguration _config;
    private Timer? _timer;
    private readonly int _heartbeat;
    private readonly PurchaseInterface? _purchaseInterface;
    private readonly string _connectionString;

    public Worker(ILogger<Worker> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;

        _heartbeat = int.TryParse(_config["ServiceConfig:HeartbeatSeconds"], out var value)
            ? value
            : 30;

        _connectionString = _config.GetConnectionString("SQLDatabase");

        if (bool.TryParse(_config["ServiceConfig:Interfaces:Purchase:Enabled"], out var enabled) && enabled)
        {
            _purchaseInterface = new PurchaseInterface(_logger, _config, _connectionString);
        }
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _timer = new Timer(RunInterfaces, null, TimeSpan.Zero, TimeSpan.FromSeconds(_heartbeat));
        return Task.CompletedTask;
    }

    private void RunInterfaces(object? state)
    {
        _logger.LogInformation("IntegrationAgentService heartbeat at {time}", DateTimeOffset.Now);
        _purchaseInterface?.Execute();
    }

    public override void Dispose()
    {
        _timer?.Dispose();
        base.Dispose();
    }
}
