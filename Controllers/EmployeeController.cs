using Microsoft.AspNetCore.Mvc;
namespace FirstProject.Controllers;
[ApiController]
[Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private UsersdbContext _departments;
         public EmployeeController(UsersdbContext Department)
            {
                _departments = Department;
            }

            // GET: api/<UsersController>
            [HttpGet]
            public IActionResult Get()
            {
                 return StatusCode(StatusCodes.Status200OK,
                "successfully Created new Employee");
            }

    }
