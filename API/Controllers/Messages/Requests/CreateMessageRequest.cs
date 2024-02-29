using System.Diagnostics.CodeAnalysis;

namespace LoverLoverBoy.Controllers.Messages;

public record CreateMessageRequest
{
    public required uint SenderId { get; set; }
    
    public required uint RecipientId { get; set; }
    
    public required string Content { get; set; }
}