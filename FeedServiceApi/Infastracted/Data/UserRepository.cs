using domain.Entities;
using domain.Interfaces;

namespace infastracted.Data;

public class UserRepository : IStoreSuggestedUser
{
    public Task<SuggestedUser[]> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<uint> AddSuggestedUser(SuggestedUser suggestedUser)
    {
        throw new NotImplementedException();
    }
}