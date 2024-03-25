using domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Interfaces;

namespace FeedServiceApi.Controllers;

public record SuggestUserRequest
{
    public required uint UserId { get; set; }
    
    public required string About { get; set; }
    
    public required int Age { get; set; }
    
    public required string PhotoId { get; set; }
}

public record SuggestUserListResponse
{
    public required SuggestUserResponse[] SuggestUserList { get; set; }
}

public record SuggestUserResponse
{
    [JsonProperty("userId")]
    public required uint UserId { get; set; }
    
    [JsonProperty("about")]
    public required string About { get; set; }
    
    [JsonProperty("age")]
    public required int Age { get; set; }
}
[ApiController]
[Route("[controller]")]
public class SuggestUserApiController : ControllerBase
{
    private readonly ICreateSuggestedUserFeed _createSuggestedUserFeed;

    public SuggestUserApiController(ICreateSuggestedUserFeed createSuggestedUserFeed)
    {
        _createSuggestedUserFeed = createSuggestedUserFeed;
    }

    [HttpGet]
    [ProducesResponseType<SuggestUserListResponse>(200)]
    public async Task<IActionResult> GetSuggestUsersListAsync()
    {
        var res = await _createSuggestedUserFeed.CreateSuggestedUserFeed();

        var response = new SuggestUserListResponse
        {
            SuggestUserList = res.Select(user => new SuggestUserResponse
            {
                UserId = user.UserId,
                About = user.About,
                Age = user.Age
            }).ToArray()
        };
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    public async Task<ActionResult> SuggestUserAsync([FromBody] SuggestUserRequest request)
    {
        await _createSuggestedUserFeed.SuggestUserAsync(new SuggestedUser
        {
            About = request.About,
            Age = request.Age,
            PhotoId = request.PhotoId,
            UserId = request.UserId
        });
        return Ok();
    }
}