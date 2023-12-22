using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DestinationDiscoveryService.Extensions;
using DestinationDiscoveryService.Middlewares;
using DestinationDiscoveryService.Data; // Import the Data namespace
using MongoDB.Driver; // Ensure you have MongoDB driver

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddHttpClient();

// Custom extension method to add destination services
builder.Services.AddDestinationServices();

// Register DestinationContext as a service
// You need to provide a way to create an IMongoDatabase instance here
builder.Services.AddSingleton<DestinationContext>(serviceProvider =>
{
    var mongoClient = new MongoClient("Your MongoDB Connection String");
    var database = mongoClient.GetDatabase("Your Database Name");
    return new DestinationContext(database);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<RequestLoggingMiddleware>();

app.MapControllers();

app.Run();
