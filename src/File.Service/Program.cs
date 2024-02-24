using File.Service.Features.Items.StoreItem;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices((context, services) =>
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(StoreItemHandler).Assembly);
        });
    })
    .Build();

host.Run();
