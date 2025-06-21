using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;





var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<QueueListener>();
    })
    //.ConfigureLogging(logging =>
    //{
    //    logging.ClearProviders();
    //    logging.AddConsole();
        
    //    // Only add EventLog on Windows
    //    if (OperatingSystem.IsWindows())
    //    {
    //        logging.AddEventLog();
    //    }
    //})
    .Build();

await builder.RunAsync();
