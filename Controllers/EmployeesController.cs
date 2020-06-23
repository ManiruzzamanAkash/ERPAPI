using System.Collections.Generic;
using System.Threading.Tasks;
using APIFuelStation.CommandBus;
using APIFuelStation.CommandBus.Commands;
using APIFuelStation.Models;
using APIFuelStation.QueryBus.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace APIFuelStation.Controllers {

    [Produces ("application/json")]
    [Route ("/api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase {
        private readonly IMediator _mediator;

        public EmployeesController (IMediator mediator) {
            this._mediator = mediator;
        }

        // [Authorize]
        /// <summary>
        /// Get All of the Employees List
        /// </summary>
        /// <returns>A New Employee </returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees () {
            var allEmployees = await _mediator.Send (new GetAllEmployeeQuery ());
            return Ok (allEmployees);
        }

        // [Authorize]
        /// <summary>
        /// Get Single Employee By ID
        /// </summary>
        /// <returns>Get an Employee</returns>
        /// <response code="404">If user id not found</response> 
        [Authorize]
        [HttpGet ("{id}", Name = "GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById (int id) {
            var user = await _mediator.Send (new GetSingleEmployeeQuery (id));
            if (user == null)
                return NotFound ();
            return Ok (user);
        }

        /// <summary>
        /// Creates a New Employee
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///         "id": 0,
        ///          "firstName": "string",
        ///          "userName": "string",
        ///          "email": "string",
        ///          "phoneNo": "string",
        ///          "gender": true,
        ///          "lastName": "string",
        ///          "password": "string",
        ///          "avatar": "string",
        ///          "joiningDate": "2020-06-23",
        ///          "designationId": 0,
        ///          "departmentId": 0
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly created Employee Item</returns>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If any of the field is null</response> 
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee (Employee user) {
            var userResponse = await _mediator.Send (new CreateEmployeeCommand (user));
            return Ok (userResponse);
        }

        /// <summary>
        /// Updates an employee
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///         "id": 1,
        ///          "firstName": "string",
        ///          "userName": "string",
        ///          "email": "string",
        ///          "phoneNo": "string",
        ///          "gender": true,
        ///          "lastName": "string",
        ///          "password": "string",
        ///          "avatar": "string",
        ///          "joiningDate": "2020-06-23",
        ///          "designationId": 0,
        ///          "departmentId": 0
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly updated Employee Item</returns>
        /// <response code="200">Returns the newly updated user</response>
        /// <response code="400">If any of the field is null</response> 
        /// <response code="404">If user id not found</response> 
        [Authorize]
        [HttpPut ("{id}", Name = "UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee (int id, Employee user) {
            var userSearchByID = await _mediator.Send (new GetSingleEmployeeQuery (id));
            if (userSearchByID == null)
                return NotFound ();

            var userResponse = await _mediator.Send (new UpdateEmployeeCommand (user));
            return Ok (userResponse);
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <returns>Deleted Employee Item</returns>
        /// <response code="200">Returns the newly deleted user</response>
        /// <response code="400">If any of the field is null</response> 
        /// <response code="404">If user id not found</response> 
        [Authorize]
        [HttpDelete ("{id}", Name = "DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee (int id) {
            var userSearchByID = await _mediator.Send (new GetSingleEmployeeQuery (id));
            if (userSearchByID == null)
                return NotFound ();

            var userResponse = await _mediator.Send (new DeleteEmployeeCommand (userSearchByID));
            return Ok (userResponse);
        }
    }
}