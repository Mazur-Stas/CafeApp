using CafeApp.Core.DTOs.Inputs;
using CafeApp.Core.Interfaces;
using CafeApp.Core.Models;
using CafeApp.Storage;
using System.Text.RegularExpressions;

namespace CafeApp.Services;

public class AuthService : IAuthService
{
    private readonly CafeAppContext _context;

    public AuthService(CafeAppContext context)
    {
        _context = context;
    }

    public Task<User> LoginAsync(LoginUserDto loginUserDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<User> RegisterAsync(RegisterUserDto registerUserDto, CancellationToken cancellationToken)
    {
        // validation
        ValidateRegisterUser(registerUserDto);

        // create user
        var user = new Customer
        {
            BirthDate = DateTime.Now.AddYears(-20),
            CreatedAt = DateTime.UtcNow,
            FirstName = registerUserDto.FirstName,
            LastName = registerUserDto.LastName,
            Login = registerUserDto.Login,
            Password = BCrypt.Net.BCrypt.HashPassword(registerUserDto.Password)
        };

        // save to db
        _context.Customers.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return user;
    }

    private void ValidateRegisterUser(RegisterUserDto registerUserDto)
    {
        if (string.IsNullOrEmpty(registerUserDto.FirstName))
        {
            throw new ArgumentException("FirstName cannot be empty", nameof(registerUserDto.FirstName));
        }

        if (string.IsNullOrEmpty(registerUserDto.LastName))
        {
            throw new ArgumentException("LastName cannot be empty", nameof(registerUserDto.LastName));
        }

        /*if (!Regex.IsMatch(registerUserDto.Password, @"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=])(?=\S+$).{8,20}$"))
        {
            throw new ArgumentException("Password is incorrect", nameof(registerUserDto.Password));
        }*/

        if (!Regex.IsMatch(registerUserDto.Login, @"^[\w\-\.]+@([\w-]+\.)+[\w-]{2,}$"))
        {
            throw new ArgumentException("Login is incorrect", nameof(registerUserDto.Login));
        }
    }
}
