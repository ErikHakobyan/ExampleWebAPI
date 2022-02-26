using DataBaseAccessLayer.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccessLayer.Data.Repositories;

public class UserRepository : IUserRepository
{
    IApplicationDbContext _context;
    public UserRepository(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }

    public async Task DeleteUser(int id)
    {
        var entity = await _context.Users.FindAsync(id);
        if (entity == null)
            throw new NotFoundException(nameof(User), id);

        _context.Users.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        var entity = await _context.Users.FindAsync(id);
        if (entity == null)
            throw new NotFoundException(nameof(User), id);

        return entity;
    }

    public async Task<IEnumerable<User>> GetUsersAsync(string sortBy = "Id")
    {
        return (await _context.Users
            .ToListAsync()).OrderDynamic(sortBy);
    }

    public async Task UpdateUser(int id, User user)
    {
        //TODO:
        var entity = await _context.Users.FindAsync(id);
        if (entity == null)
            throw new NotFoundException(nameof(User), id);

        entity.Name = user.Name;
        entity.UserType = user.UserType;

        await _context.SaveChangesAsync();
    }
}

