using datalayer;
using ExampleCore.TraceIdLogic;
using LogicStartUp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.TryAddLogic();
builder.Services.TryAddDal();

builder.Services.TryAddTraceId();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// TODO: commit
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


