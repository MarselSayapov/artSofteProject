var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/// <summary>
/// Message
/// </summary>
public class Message
{
    /// <summary>
    /// message id
    /// </summary>
    public uint Id { get; set; }
    
    /// <summary>
    /// message content
    /// </summary>
    public string Content { get; set; }
    
    /// <summary>
    /// message sender id
    /// </summary>
    public uint SenderId { get; set; }
    
    /// <summary>
    /// message recipient id
    /// </summary>
    public uint RecipientId { get; set; }
}


