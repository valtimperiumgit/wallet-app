using WalletApp.Application.Abstractions.Authentication;
using WalletApp.Application.Core.Cryptography;
using WalletApp.Application.Core.Exceptions;
using WalletApp.Application.Services;
using WalletApp.Contracts.Authentication;
using WalletApp.Contracts.Users;
using WalletApp.Domain.Entities.UserNamespace;

namespace WalletApp.Infrastructure.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserService _userService;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public AuthenticationService(IUserService userService, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
    {
        _userService = userService;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public async Task<AuthenticationResponse> Registration(RegistrationRequest request)
    {
        var existingUser = await _userService.GetUserByEmail(request.Email);

        if (existingUser is not null)
        {
            throw ApplicationExceptions.User.UserAlreadyExist;
        }

        var newUser = new User(
            Guid.NewGuid(),
            request.Name,
            _passwordHasher.Hash(request.Password),
            request.Email
        );

        await _userService.CreateUser(newUser);

        return BuildAuthenticationResponse(newUser);
    }

    public async Task<AuthenticationResponse> Login(LoginRequest request)
    {
        var user = await _userService.GetUserByEmail(request.Email);

        if (user is null || user.Password != _passwordHasher.Hash(request.Password))
        {
            throw ApplicationExceptions.Authentication.InvalidEmailOrPassword;
        }

        return BuildAuthenticationResponse(user);
    }

    private AuthenticationResponse BuildAuthenticationResponse(User user)
    {
        return new AuthenticationResponse
        {
            User = new UserResponse(user),
            Token = _jwtProvider.Create(AuthenticationClaims.ForUser(user))
        };
    }
}