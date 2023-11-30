using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using FirstProject.Application.Queries;
using FirstProject.DTO;
using FirstProject.Application.Commands;
using FirstProject.Application.Command;
using Microsoft.AspNetCore.Authorization;


namespace FirstProject.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
public class DepartmentController: ControllerBase
{
     private readonly IMediator _mediator;
         public DepartmentController(IMediator mediator)
            {
                _mediator = mediator;
                 
            }
             // GET: api/<UsersController>
            [HttpGet]
            public async Task<IEnumerable<Department>> getAllAsync()
            {
            var allDepartmentData = await _mediator.Send(new GetDepartmentsQuery());
            return  allDepartmentData;
            }
          [HttpGet("{Deptid:guid}")]
            public async Task<Department> GetOneAsync(Guid deptid){
            var SingleDep = await _mediator.Send(new GetDepartmentByidQuery(){Deptid=deptid});
            return SingleDep;
            }

    // POST api/<UsersController>
    [HttpPost] 
                public async Task<IActionResult> Create([FromBody] DepartmentDto command)
                {
                if(!ModelState.IsValid){
                    return BadRequest(ModelState);
                }
                var cmd = new CreateDepartmentCommand(command.Deptname, command.Description, command.Parentid);
                   var SingleDep = await _mediator.Send(cmd);
                    return Ok(SingleDep);

                }  
    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
        public async Task<object> PutAsync([FromBody] DepartmentUpdateDto model,Guid id)
        {
             model.Deptid=id;
          var cmd = new UpdateDepartmentCommand(model.Deptid,model.Deptname,model.Description,model.Parentid);
           var updDep = await _mediator.Send(cmd);
                    return Ok(updDep);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteDepartmentAsync(Guid id)
    {
           var deleteDep = await _mediator.Send(new DeleteDepartmentCommand(){Deptid=id});
            return Ok(deleteDep);
    }

   }


    //corseera
    //chatGPT
    //BlockChain
