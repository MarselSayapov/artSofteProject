using domain.Entities;

namespace domain.Interfaces;

public interface IStoreSuggestedUser
{
    Task<SuggestedUser[]> GetAllAsync();

    Task<uint> AddSuggestedUser(SuggestedUser suggestedUser);
}