namespace LoverLoverBoy.Controllers.Messages.Responses;

public class MessageInfoResponse
{
    public required Guid Id { get; set; }
    public required string Content { get; set; }

    public required uint SenderId { get; set; }

    public required uint RecipientId { get; set; }
}