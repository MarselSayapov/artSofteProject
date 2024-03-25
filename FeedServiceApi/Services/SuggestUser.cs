using domain.Entities;
using domain.Interfaces;
using ProfileConnectionLib.ConnectionServices.Interfaces;

namespace Service;

public class SuggestUser
{
    private readonly IStoreSuggestedUser _storePost;

    private readonly ICheckUser _checkUser;

    private readonly IProfileConnectionService _profileConnectionService;

    public SuggestUser(IStoreSuggestedUser storePost, ICheckUser checkUser, IProfileConnectionService profileConnectionService)
    {
        _storePost = storePost;
        _checkUser = checkUser;
        _profileConnectionService = profileConnectionService;
    }

    public async Task<SuggestedUser[]> GetSuggestedUserListAsync(uint[] ids)
    {
        var suggestedUsersList = await _storePost.GetAllAsync();
        var userIdList = suggestedUsersList.Select(user => user.UserId).ToArray();
        return suggestedUsersList.ToArray();
    }

    public async Task<uint> SuggestUserAsync(SuggestedUser suggestedUser)
    {
        var res = await _storePost.AddSuggestedUser(suggestedUser);
        return res;
    }
}