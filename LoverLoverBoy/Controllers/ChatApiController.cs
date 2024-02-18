using Microsoft.AspNetCore.Mvc;

namespace LoverLoverBoy.Controllers;


[ApiController]
[Route("[controller]")]
public class ChatApiController
{
    /// <summary>
    /// Gets all incoming user's messages by his Id
    /// </summary>
    /// <param name="userId">Required user id</param>
    /// <returns>Enumerable object that contains all incoming messages of this user</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IActionResult> GetAllIncomingUserMessagesAsync(uint userId)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// Gets all outcoming user's messages by his Id
    /// </summary>
    /// <param name="userId">Required user id</param>
    /// <returns>Enumerable object that contains all outcoming messages of this user</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IActionResult> GetAllOutComingUserMessagesAsync(uint userId)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// sends a message to another user
    /// </summary>
    /// <param name="message">message with content and sender, recipient id</param>
    /// <returns>message to another user</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IActionResult> SendMessageAsync(Message message)
    {
        throw new NotImplementedException();
    }

}