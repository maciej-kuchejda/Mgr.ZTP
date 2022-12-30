using Kuchejda.ZTP.WebApi.Clients;
using Kuchejda.ZTP.WebApi.Configuration;
using Kuchejda.ZTP.WebApi.Generatos;
using Kuchejda.ZTP.WebApi.Providers;
using Kuchejda.ZTP.WebApi.Services;
using Kuchejda.ZTP.WebApi.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();

RegisterModules(builder, builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
    c.EnableAnnotations();
});
builder.Services.AddVersionedApiExplorer(o =>
{
    o.GroupNameFormat = "'v'VVV";
    o.SubstituteApiVersionInUrl = true;
});


const string CORS_POLICY = "CorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CORS_POLICY,
                      builder =>
                      {
                          builder.AllowAnyOrigin();
                          builder.AllowAnyMethod();
                          builder.AllowAnyHeader();
                      });
});

builder.Services.AddControllers();
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BusinessCards V1");
});

app.UseRouting();
app.Logger.LogInformation("LAUNCHING API");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();


void RegisterModules(WebApplicationBuilder builder, ConfigurationManager configuration)
{
    var services = builder.Services;
    services.AddOptions();
    services.Configure<QueueConfiguration>(x => configuration.GetSection("QueueConfiguration").Bind(x));

    services.AddScoped<IQueueService, QueueService>();
    services.AddScoped<IBusinessCardValidator, BusinessCardValidator>();
    services.AddScoped<IIdProvider, IdProvider>();
    services.AddScoped<IIdGenerator, IdGenerator>();

    services.AddScoped<IQueueClient, QueueClient>();
    services.AddScoped<IQueuePropertiesProvider, QueueClient>();
    services.AddScoped<IJsonProvider, JsonProvider>();
    services.AddScoped<IServiceBusMessageBatchService, ServiceBusMessageBatchService>();
}