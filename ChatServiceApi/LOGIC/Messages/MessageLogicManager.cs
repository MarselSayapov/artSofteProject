using datalayer.Messages.Interfaces;
using datalayer.Messages.Models;
using LogicStartUp.Messages.Interfaces;
using LogicStartUp.Messages.Models;

namespace LogicStartUp.Messages;

public class MessageLogicManager : IMessageLogicManager
{
    private readonly IMessageRepository _messageRepository;

    public MessageLogicManager(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<Guid> CreateMessageAsync(MessageLogic message)
    {
        return await _messageRepository.CreateMessageAsync(new MessageDal
        {
            Content = message.Content,
            RecipientId = message.RecipientId,
            SenderId = message.SenderId,
            Id = Guid.NewGuid()
        });
        
    }

    public async Task<MessageDal[]> GetIncomingMessagesByUserIdAsync(uint userId)
    {
        return await _messageRepository.GetIncomingMessagesByUserIdAsync(userId);
    }

    public async Task<MessageDal[]> GetOutgoingMessagesByUserIdAsync(uint userId)
    {
        return await _messageRepository.GetOutgoingMessagesByUserIdAsync(userId);
    }
}