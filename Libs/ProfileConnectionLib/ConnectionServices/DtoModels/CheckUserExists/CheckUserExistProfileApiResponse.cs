namespace ProfileConnectionLib.ConnectionServices.DtoModels.CheckUserExists;

public record CheckUserExistProfileApiResponse
{
    public required uint UserId { get; init; }
}