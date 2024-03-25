using LogicStartUp.Messages.Interfaces;
using LogicStartUp.Messages.Models;
using LoverLoverBoy.Controllers.Messages;
using LoverLoverBoy.Controllers.Messages.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LoverLoverBoy.Controllers;


[ApiController]
[Route("[controller]")]
public class ChatApiController : ControllerBase
{
    private readonly IMessageLogicManager _messageLogicManager;

    public ChatApiController(IMessageLogicManager messageLogicManager)
    {
        _messageLogicManager = messageLogicManager;
    }

    /// <summary>
    /// Gets all incoming user's messages by his Id
    /// </summary>
    /// <param name="userId">Required user id</param>
    /// <returns>Enumerable object that contains all incoming messages of this user</returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet("incoming")]
    public async Task<IActionResult> GetAllIncomingUserMessagesAsync([FromQuery] uint userId)
    {
        var messages = await _messageLogicManager.GetIncomingMessagesByUserIdAsync(userId);
        var messagesResponse = messages.Select(message => new MessageInfoResponse
        {
            Content = message.Content,
            RecipientId = message.RecipientId,
            SenderId = message.SenderId,
            Id = message.Id
        }).ToList();
        return Ok(messagesResponse);
    }
    
    /// <summary>
    /// Gets all outcoming user's messages by his Id
    /// </summary>
    /// <param name="userId">Required user id</param>
    /// <returns>Enumerable object that contains all outcoming messages of this user</returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet("outgoing")]
    public async Task<IActionResult> GetAllOutgoingUserMessagesAsync(uint userId)
    {
        var messages = await _messageLogicManager.GetOutgoingMessagesByUserIdAsync(userId);
        var messagesResponse = messages.Select(message => new MessageInfoResponse
        {
            Content = message.Content,
            RecipientId = message.RecipientId,
            SenderId = message.SenderId,
            Id = message.Id
        });
        return Ok(messagesResponse);
    }

    /// <summary>
    /// sends a message to another user
    /// </summary>
    /// <param name="messageRequest">message model request from client</param>
    /// <returns>message to another user</returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPost]
    public async Task<IActionResult> CreateMessageAsync(CreateMessageRequest messageRequest)
    {
        var res = await _messageLogicManager.CreateMessageAsync(new MessageLogic
        {
            Content = messageRequest.Content,
            RecipientId = messageRequest.RecipientId,
            SenderId = messageRequest.SenderId
        });
        return Ok(new CreateMessageResponse
        {
            Id = res
        });
    }

}