
using APIdemo.Model;
using ErrorOr;

public interface IUserService
{
    ErrorOr<Users> CreateUser(Users user);
    ErrorOr<Users> GetUser(Guid id);
    ArraySegment<Users> GetUsers();
    ErrorOr<Users> UpdateUser(Guid id ,Users user);
    ErrorOr<Users> DeleteUser(Guid id);
}
