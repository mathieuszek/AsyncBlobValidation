using File.Service.Features.Items.ListItemStorages;
using File.Service.Features.Items.StoreItem;
using File.Service.Settings;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices((context, services) =>
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(StoreItemHandler).Assembly);
        });

        services.AddAzureClients(builder =>
        {
            var blobConnectionString = context.Configuration.GetConnectionString("DefaultBlob")
                ?? throw new InvalidDataException("ConnectionString__DefaultBlob must be defined.");
            builder.AddBlobServiceClient(blobConnectionString);
        });
        services
            .AddOptions<BlobStorageSettings>()
            .Bind(context.Configuration.GetSection(BlobStorageSettings.SettingsKey));

        services.AddScoped<IListStoredItemsService, ListStoredItemsBlobService>();
        services.AddScoped<IStoreItemService, ItemsBlobStorageService>();
    })
    .Build();

host.Run();
