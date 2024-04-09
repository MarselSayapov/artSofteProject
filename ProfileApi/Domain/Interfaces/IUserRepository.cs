using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(uint id);

    Task<User[]> GetAllUsersAsync();
}