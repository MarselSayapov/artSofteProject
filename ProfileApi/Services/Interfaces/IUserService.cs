using Domain.Entities;

namespace Services.Interfaces;

public interface IUserService
{
    Task<User> GetUserByIdAsync(uint id);

    Task<uint> CheckUserExist(uint id);

    Task<User[]> GetAllUsersAsync();
}