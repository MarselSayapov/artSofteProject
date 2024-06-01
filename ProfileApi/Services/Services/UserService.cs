using Domain.Entities;
using Domain.Interfaces;
using Services.Interfaces;

namespace Services.Services;

public class UserService : IUserService
{
    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserByIdAsync(uint id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }

    public async Task<User[]> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }
    
    public async Task<uint> CheckUserExist(uint userId)
    {
        var res = await _userRepository.CheckUserExist(userId);
        return res.Id;
    }
}