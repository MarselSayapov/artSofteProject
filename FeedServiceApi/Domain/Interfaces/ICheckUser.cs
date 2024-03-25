namespace domain.Interfaces;

public interface ICheckUser
{
    Task CheckUserExistAsync(uint userId);
}