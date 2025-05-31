using CafeApp.Core.DTOs.Inputs;
using CafeApp.Core.Interfaces;
using CafeApp.Core.Models;
using CafeApp.Storage;
using System.Text.RegularExpressions;

namespace CafeApp.Services;

public class AuthService : IAuthService
{
    private readonly IUserAuthRepository _userRepository;

    public AuthService(IUserAuthRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> LoginAsync(LoginUserDto loginUserDto, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByLoginAsync(loginUserDto.Login, cancellationToken);

        if (user == null || !BCrypt.Net.BCrypt.Verify(loginUserDto.Password, user.Password))
        {
            throw new UnauthorizedAccessException("Invalid login or password");
        }

        return user;
    }

    public async Task<User> RegisterAsync(RegisterUserDto registerUserDto, CancellationToken cancellationToken)
    {
        ValidateRegisterUser(registerUserDto);

        var existingUser = await _userRepository.GetByLoginAsync(registerUserDto.Login, cancellationToken);
        if (existingUser != null)
        {
            throw new ArgumentException("User with this login already exists");
        }

        var user = new Customer
        {
            BirthDate = DateTime.Now.AddYears(-20),
            CreatedAt = DateTime.UtcNow,
            FirstName = registerUserDto.FirstName,
            LastName = registerUserDto.LastName,
            Login = registerUserDto.Login,
            Password = BCrypt.Net.BCrypt.HashPassword(registerUserDto.Password)
        };

        await _userRepository.AddAsync(user, cancellationToken);
        return user;
    }

    private void ValidateRegisterUser(RegisterUserDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.FirstName))
            throw new ArgumentException("FirstName cannot be empty");

        if (string.IsNullOrWhiteSpace(dto.LastName))
            throw new ArgumentException("LastName cannot be empty");

        if (!Regex.IsMatch(dto.Login, @"^[\w\-\.]+@([\w-]+\.)+[\w-]{2,}$"))
            throw new ArgumentException("Login must be a valid email");

        if (dto.Password.Length < 6)
            throw new ArgumentException("Password must be at least 6 characters");
    }
}
