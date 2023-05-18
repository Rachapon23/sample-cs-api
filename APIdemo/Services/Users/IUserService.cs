
using APIdemo.Model;
using ErrorOr;

public interface IUserService
{
    void CreateUser(Users user);
    ErrorOr<Users> GetUsers(Guid id);
}
