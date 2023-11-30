using FirstProject.Models;
using FirstProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace FirstProject.Controllers
{
 //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _users;
        private readonly IJWTTokenServices _jwttokenservice;

        // GET: api/<UsersController>

        public UsersController(IUsers users,IJWTTokenServices jWTTokenServices)
        {
            _users = users;
            _jwttokenservice = jWTTokenServices;
        }

        [HttpPost]
        [Route("signup")]
        public IActionResult Signup([FromBody] User user)
        {
            
            return Ok(_users.Signup(user));
        }

      //  [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Authenticate(User users)
        {
            var token = _jwttokenservice.Authenticate(users);   

            if (token == null)
            {
                return Ok(new { Message = "Unauthorized" });
            }

            return Ok(token);
        }
 }
}