using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class UserRepository : IUserRepository
{
    private UserDbContext _dbContext;

    public UserRepository(UserDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetUserByIdAsync(uint id)
    {
        return await _dbContext.Users.FindAsync(id);
    }

    public async Task<User> CheckUserExist(uint id)
    {
        return await _dbContext.Users.FindAsync(id);
    }

    public async Task<User[]> GetAllUsersAsync()
    {
        return await _dbContext.Users.ToArrayAsync();
    }
}