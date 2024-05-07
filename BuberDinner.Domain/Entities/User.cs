namespace BubberDinner.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null;
    public string LastName { get; set; } = null;
    public string Email { get; set; } = null;
    public string Password { get; set; } = null;

    public User(string firstName, string lastName, string email, string password)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email; 
        this.Password = password;
    }

}