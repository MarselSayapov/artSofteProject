using ExampleCore.HttpLogic;
using ExampleCore.TraceIdLogic;
using Infrastructure;
using Microsoft.Extensions.ObjectPool;
using ProfileConnectionLib.ConnectionServices.RabbitConnectionServer;
using RabbitMQ.Client;
using Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.TryAddInfrastructed();
builder.Services.AddHttpRequestService();
builder.Services.TryAddService();
builder.Services.TryAddTraceId();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ObjectPool<IConnection>>(serviceProvider =>
{
    return new DefaultObjectPool<IConnection>(new RabbitConnectionPool("localhost"), Environment.ProcessorCount * 2);
});
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