using QuizB.DAL.Configurations;

namespace QuizB.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository()
    {
        _context = new AppDbContext();
    }

    public string GetUserFullName(int id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);

        if (user is null)
        {

        }
        else
        {
            return $"{user.FirstName} {user.LastName}";
        }

        return string.Empty;
    }
}