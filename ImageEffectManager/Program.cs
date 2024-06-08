using ImageManipulator.BLL.Services;
using ImageManipulator.Core.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

builder.Host.ConfigureServices((hostContext, services) =>
{
    services.AddSingleton<IConfiguration>(builder.Configuration);
});

var services = builder.Services;

services.AddSwaggerGen();
services.AddScoped<IImageProcessingService, ImageProcessingService>();
services.AddSingleton<IPluginManagementService, PluginManagementService>(); 

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();