namespace LogicStartUp.Messages.Models;

/// <summary>
/// Message entity in logic layer
/// </summary>
public class MessageLogic
{
    /// <summary>
    /// Контент сообщения
    /// </summary>
    public required string Content { get; set; }
    
    /// <summary>
    /// Id отправителя
    /// </summary>
    public required uint SenderId { get; set; }
    
    /// <summary>
    /// Id получателя
    /// </summary>
    public required uint RecipientId { get; set; }
}