using System.Collections.Generic;
using System.Threading.Tasks;
using APIFuelStation.CommandBus;
using APIFuelStation.CommandBus.Commands;
using APIFuelStation.Models;
using APIFuelStation.QueryBus;
using APIFuelStation.QueryBus.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace APIFuelStation.Controllers
{

    [Produces("application/json")]
    [Route("/api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // [Authorize]
        /// <summary>
        /// Get All of the Departments List
        /// </summary>
        /// <returns>A New Department </returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var allDepartments = await _mediator.Send(new GetAllDepartmentQuery());
            return Ok(allDepartments);
        }

        // [Authorize]
        /// <summary>
        /// Get Single Department By ID
        /// </summary>
        /// <returns>Get an Department</returns>
        /// <response code="404">If user id not found</response> 
        [Authorize]
        [HttpGet("{id}", Name = "GetDepartmentById")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var user = await _mediator.Send(new GetSingleDepartmentQuery(id));
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        /// <summary>
        /// Creates a New Department
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///         "id": 0,
        ///         "name": "Department 1",
        ///         "code": "DEP12",
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly created Department Item</returns>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If any of the field is null</response> 
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(Department user)
        {
            var userResponse = await _mediator.Send(new CreateDepartmentCommand(user));
            return Ok(userResponse);
        }

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///         "id": 0,
        ///         "firstName": "Maniruzzaman",
        ///         "lastName": "Akash",
        ///         "userName": "maniruzzaman",
        ///         "email": "maniruzzamanAkash@gmail.com",
        ///         "phoneNo": "01951233084",
        ///         "password": "123456",
        ///         "avatar": "string",
        ///         "gender": true
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly updated Department Item</returns>
        /// <response code="200">Returns the newly updated user</response>
        /// <response code="400">If any of the field is null</response> 
        /// <response code="404">If user id not found</response> 
        [Authorize]
        [HttpPut("{id}", Name = "UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment(int id, Department user)
        {
            var departmentSearchByID = await _mediator.Send(new GetSingleDepartmentQuery(id));
            if (departmentSearchByID == null)
                return NotFound();

            var userResponse = await _mediator.Send(new UpdateDepartmentCommand(user));
            return Ok(userResponse);
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <returns>Deleted Department Item</returns>
        /// <response code="200">Returns the newly deleted user</response>
        /// <response code="400">If any of the field is null</response> 
        /// <response code="404">If user id not found</response> 
        [Authorize]
        [HttpDelete("{id}", Name = "DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var departmentSearchByID = await _mediator.Send(new GetSingleDepartmentQuery(id));
            if (departmentSearchByID == null)
                return NotFound();

            var userResponse = await _mediator.Send(new DeleteDepartmentCommand(departmentSearchByID));
            return Ok(userResponse);
        }
    }
}