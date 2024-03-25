using System.ComponentModel.DataAnnotations;

namespace datalayer.Messages.Models;

/// <summary>
/// Message entity in data access layer
/// </summary>
public class MessageDal
{
    [Key]
    public required Guid Id { get; set; }
    
    
    /// <summary>
    /// Message content
    /// </summary>
    public required string Content { get; set; }
    
    /// <summary>
    /// Message sender id
    /// </summary>
    public required uint SenderId { get; set; }
    
    /// <summary>
    /// Message recipient id
    /// </summary>
    public required uint RecipientId { get; set; }
}