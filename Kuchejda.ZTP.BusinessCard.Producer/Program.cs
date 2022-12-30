using Kuchejda.ZTP.BusinessCard.Producer.Clients;
using Kuchejda.ZTP.BusinessCard.Producer.Configuration;
using Kuchejda.ZTP.BusinessCard.Producer.Providers;
using Kuchejda.ZTP.BusinessCard.Producer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RandomNameGeneratorLibrary;

Console.WriteLine("Producer starting");
Console.WriteLine("Registering dependencies");
var serviceCollection = new ServiceCollection();

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

RegisterDependencies(serviceCollection, configuration);

var serviceProvider = serviceCollection.BuildServiceProvider();

Console.WriteLine("Dependencies registered");

using (var scope = serviceProvider.CreateScope())
{
    var service = scope.ServiceProvider.GetService<IBusinessCardProvider>();
    var dataService = scope.ServiceProvider.GetService<IDataService>();

    var fakeData = dataService.Generate(10);

    await service.UploadAsync(fakeData);
}

void RegisterDependencies(ServiceCollection serviceCollection, IConfiguration configuration)
{
    serviceCollection.AddOptions();

    serviceCollection.Configure<BusinessCardConfiguration>(x=> configuration.GetSection("BusinessCardConfiguration").Bind(x));

    serviceCollection.AddScoped<IBusinessCardClient, BusinessCardClient>();
    serviceCollection.AddScoped<IBusinessCardDataBuilder, BusinessCardDataBuilder>();
    serviceCollection.AddScoped<IBusinessCardProvider, BusinessCardProvider>();//PersonNameGenerator
    serviceCollection.AddScoped<IPersonNameGenerator, PersonNameGenerator>();
    serviceCollection.AddScoped<IDataService, DataService>();

}
