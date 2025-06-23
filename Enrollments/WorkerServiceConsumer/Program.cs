using WorkerServiceConsumer;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<QueueListener>();
    })
    .Build();

await host.RunAsync();
