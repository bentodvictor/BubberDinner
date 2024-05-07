using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Domain.Entities;
using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password) 
    {

        // Check if user already exists
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists.");
        }

        var user = new User(firstName, lastName, email, password);

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(
            user,
            token);
    }

    public AuthenticationResult Login(string email, string password) 
    {
        // Check user
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("The given email or/and password may not be correct.");
        }

        // Validate password
        if(user.Password != password)
        {
            throw new Exception("The given email or/and password may not be correct.");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

}