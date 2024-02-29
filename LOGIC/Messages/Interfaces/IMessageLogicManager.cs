using datalayer.Messages.Models;
using LogicStartUp.Messages.Models;

namespace LogicStartUp.Messages.Interfaces;

public interface IMessageLogicManager
{
    /// <summary>
    /// Отправить сообщение
    /// </summary>
    /// <returns></returns>
    Task<Guid> CreateMessageAsync(MessageLogic message);

    Task<MessageDal[]> GetIncomingMessagesByUserIdAsync(uint userId);

    Task<MessageDal[]> GetOutgoingMessagesByUserIdAsync(uint userId);
}