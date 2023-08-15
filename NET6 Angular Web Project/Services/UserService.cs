using NET6_Angular_Web_Project.Data;
using NET6_Angular_Web_Project.Models;

public class UserService
{
    private readonly ApplicationDBContext _dbContext;

    public UserService(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> RegisterUser(User userToRegister)
    {
        _dbContext.Users.Add(userToRegister);
        await _dbContext.SaveChangesAsync();

        return userToRegister;
    }
}