using APIdemo.Model;
using ErrorOr;

public class UserService : IUserService
{
    private static readonly Dictionary<Guid, Users> _users = new();
    public void CreateUser(Users user)
    {
        _users.Add(user._id, user);
    }

    public ErrorOr<Users> GetUsers(Guid _id)
    {
        if(_users.TryGetValue(_id, out var user))
        {
            return user;
        }
        return Errors.User.NotFound;
    }
}
