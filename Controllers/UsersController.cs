using APIdemo.Model;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIdemo.Controllers; 

[Route("api/[controller]")]
[ApiController]
public class UsersController : ApiController
{
    private readonly IUserService _userServices;

    public UsersController(IUserService userServices)
    {
        _userServices = userServices;
    }

    // GET: api/Users
    [HttpGet]
    public IActionResult GetUsers()
    {
        var res = _userServices.GetUsers();
        return Ok(res);
    }

    // GET api/Users/5
    [HttpGet("{_id:guid}")]
    public IActionResult GetUser(Guid _id)
    {
        ErrorOr<Users> userResult = _userServices.GetUser(_id);

        return userResult.Match(
            user => Ok(MapUserResponse(user)),
            errors => Problem(errors)
        );
    }

    public static UserResponse MapUserResponse(Users user)
    {
        return new UserResponse(
            user._id,
            user.firstname,
            user.lastname,
            user.email
        );
    }


    // POST api/Users
    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest req)
    {
        var user = new Users(
            Guid.NewGuid(),
            req.firstname,
            req.lastname,
            req.email
        );

        ErrorOr<Users> createUserResult = _userServices.CreateUser(user);

        return createUserResult.Match(
            update => CreatedAtAction(
                actionName: nameof(CreateUser),
                routeValues: new { user._id },
                value: MapUserResponse(user)
            ),
            errors => Problem(errors)
        );

    }

    // PUT api/Users/5
    [HttpPut("{_id:guid}")]
    public IActionResult UpdateUser(Guid _id, UpdateUserRequest req)
    {
        var user = new Users(
            _id,
            req.firstname,
            req.lastname,
            req.email
        );
        ErrorOr<Users> updateResult = _userServices.UpdateUser(_id, user);

        return updateResult.Match(
            update => Ok(update),
            errors => Problem(errors)
        );
    }

    // DELETE api/Users/5
    [HttpDelete("{_id:guid}")]
    public IActionResult DeleteUser(Guid _id)
    {
        ErrorOr<Users> deleteResult = _userServices.DeleteUser(_id);

        return deleteResult.Match(
            deleted => Ok(deleted),
            errors => Problem(errors)
        );
    }
}


