namespace ProfileConnectionLib.ConnectionServices.DtoModels.CheckUserExists;

public record CheckUserExistProfileApiRequest
{
    public required uint UserId { get; set; }
}
