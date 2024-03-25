using domain.Entities;

namespace Service.Interfaces;

public interface ICreateSuggestedUserFeed
{
    Task SuggestUserAsync(SuggestedUser suggestedUser);

    Task<SuggestedUser[]> CreateSuggestedUserFeed();
}