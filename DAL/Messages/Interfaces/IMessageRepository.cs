using datalayer.Messages.Models;

namespace datalayer.Messages.Interfaces;

public interface IMessageRepository
{
    public Task<MessageDal[]> GetIncomingMessagesByUserIdAsync(uint userId);

    public Task<MessageDal[]> GetOutgoingMessagesByUserIdAsync(uint userId);
    public Task<Guid> CreateMessageAsync(MessageDal messageDal);
}