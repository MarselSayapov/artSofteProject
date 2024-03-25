using ProfileConnectionLib.ConnectionServices.DtoModels.CheckUserExists;
using ProfileConnectionLib.ConnectionServices.DtoModels.UserNameLists;

namespace ProfileConnectionLib.ConnectionServices.Interfaces;

public interface IProfileConnectionService
{
    Task<UserNameListProfileApiResponse[]> GetUserNameListAsync(UserNameListProfileApiRequest request);

    Task<CheckUserExistProfileApiResponse> CheckUserExistAsync(CheckUserExistProfileApiRequest checkUserExistProfileApiRequest);
}