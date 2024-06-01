using ExampleCore.HttpLogic;
using ExampleCore.TraceIdLogic;
using Infrastructure;
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