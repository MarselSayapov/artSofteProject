using datalayer.Messages.Contexts;
using datalayer.Messages.Interfaces;
using datalayer.Messages.Models;
using Microsoft.EntityFrameworkCore;

namespace datalayer.Messages;
/// <summary>
/// Database access repository
/// </summary>
public class MessageRepository : IMessageRepository
{
    /// <summary>
    /// Messages database context
    /// </summary>
    private MessageContext _messageContext = new MessageContext();
    
    /// <summary>
    /// Get incoming messages by user id
    /// </summary>
    /// <param name="messageId">Message Id</param>
    /// <returns>Message DAL model</returns>
    /// <exception cref="Exception">Something went wrong...</exception>
    public async Task<MessageDal[]> GetIncomingMessagesByUserIdAsync(uint userId)
    {
        try
        {
            return await _messageContext.Messages.Where(message => message.RecipientId == userId).ToArrayAsync();
        }
        catch (Exception e)
        {
            throw new Exception("По заданному Id не найдено ни одного сообщения.");
        }
    }

    public async Task<MessageDal[]> GetOutgoingMessagesByUserIdAsync(uint userId)
    {
        try
        {
            return await _messageContext.Messages.Where(message => message.SenderId == userId).ToArrayAsync();
        }
        catch (Exception e)
        {
            throw new Exception("По заданному Id не найдено ни одного сообщения.");
        }
    }

    /// <summary>
    /// Create and add message to database
    /// </summary>
    /// <param name="message">Message DAL model object</param>
    /// <returns>Added to database message Id</returns>
    /// <exception cref="Exception">Something went wrong...</exception>
    public async Task<Guid> CreateMessageAsync(MessageDal message)
    {
        try
        {
            await _messageContext.Messages.AddAsync(message);
            await _messageContext.SaveChangesAsync();
            return message.Id;
        }
        catch (Exception e)
        {
            throw new Exception("Ошибка при отправке сообщения.");
        }
    }
}