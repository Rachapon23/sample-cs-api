using APIdemo.Model;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIdemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
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
            return Ok("USer");
        }

        // GET api/Users/5
        [HttpGet("{_id:guid}")]
        public IActionResult GetUser(Guid _id)
        {
            Console.WriteLine(_id);
            ErrorOr<Users> userResult = _userServices.GetUsers(_id);
            
            if(userResult.IsError && userResult.FirstError == Errors.User.NotFound)
            {
                return NotFound();
            }

            var user = userResult.Value;
            var res = new UserResponse(
                user._id,
                user.firstname,
                user.lastname,
                user.email
            );

            return Ok(res);
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

            _userServices.CreateUser(user);

            var res = new UserResponse(
                user._id,
                user.firstname,
                user.lastname,
                user.email
            );
            return CreatedAtAction(
                actionName: nameof( CreateUser ),
                routeValues: new { _id = user._id },
                value: res
            );
        }

        // PUT api/Users/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] string value)
        {
            return Ok(id);
        }

        // DELETE api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            return Ok(id);
        }
    }
}
