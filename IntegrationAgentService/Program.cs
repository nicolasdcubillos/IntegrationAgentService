using System.Runtime.InteropServices;

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.Sources.Clear(); // Quita cualquier fuente previa
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
    });

if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    builder.UseWindowsService();
}

builder.Build().Run();
