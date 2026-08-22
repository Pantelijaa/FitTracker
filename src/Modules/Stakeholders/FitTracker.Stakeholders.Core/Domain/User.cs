using FitTracker.BuildingBlocks.Core.Domain;

namespace FitTracker.Stakeholders.Core.Domain
{
    public enum UserRole
    {
        Trainee,
        Trainer
    }
    public abstract class User : Entity
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string HashedPassword { get; private set; }
        public UserRole Role { get; private set; }

        public User(string  username, string email, string hashedPassword, UserRole role)
        {
            Username = username;
            Email = email;
            HashedPassword = hashedPassword;
            Role = role;
        }
    }
}
