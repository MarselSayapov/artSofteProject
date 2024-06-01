namespace ProfileConnectionLib.ConnectionServices.DtoModels.UserNameLists;

public record UserNameListProfileApiResponse
{
    public required uint[] UsersIdList { get; set; }
}
