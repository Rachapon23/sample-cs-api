using APIdemo.Model;
using ErrorOr;

public class UserService : IUserService
{
    private static readonly Dictionary<Guid, Users> _users = new();
    public ErrorOr<Users> CreateUser(Users user)
    {
        _users.Add(user._id, user);
        return _users[user._id];
    }

    public ErrorOr<Users> GetUser(Guid _id)
    {
        if(_users.TryGetValue(_id, out var user))
        {
            return user;
        }
        return Errors.User.NotFound;
    }

    public ArraySegment<Users> GetUsers() {
        return _users.Values.ToArray();
    }

    public ErrorOr<Users> DeleteUser(Guid _id)
    {
        if (_users.ContainsKey(_id))
        {
            var user = _users[_id];
            _users.Remove(_id);
            return user;
        }
        return Errors.User.NotFound;
    }

    public ErrorOr<Users> UpdateUser(Guid _id, Users user)
    {
        if(_users.ContainsKey(_id))
        {
            _users[_id] = user;
            return _users[_id];
        }
        return Errors.User.NotFound;
        
    }
}
