using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Domain.Entities;

namespace BubberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly static List<User> _users = new List<User>();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}