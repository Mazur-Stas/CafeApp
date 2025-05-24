using CafeApp.Core.DTOs.Inputs;
using CafeApp.Core.Models;

namespace CafeApp.Core.Interfaces;

public interface IAuthService
{
    Task<User> RegisterAsync(RegisterUserDto registerUserDto, CancellationToken cancellationToken);
    Task<User> LoginAsync(LoginUserDto loginUserDto, CancellationToken cancellationToken);
}
