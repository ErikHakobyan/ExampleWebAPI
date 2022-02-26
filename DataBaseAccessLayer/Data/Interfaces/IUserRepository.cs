namespace DataBaseAccessLayer.Data.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(int id);
    Task<IEnumerable<User>> GetUsersAsync(string sortBy);
    Task<int> CreateUserAsync(User user);
    Task UpdateUser(int id, User user);
    Task DeleteUser(int id);
}

