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
    public class UsersController : ControllerBase {
        private readonly IMediator _mediator;

        public UsersController (IMediator mediator) {
            this._mediator = mediator;
        }

        // [Authorize]
        /// <summary>
        /// Get All of the Users List
        /// </summary>
        /// <returns>A New User </returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers () {
            var allUsers = await _mediator.Send (new GetAllUserQuery ());
            return Ok (allUsers);
        }

        // [Authorize]
        /// <summary>
        /// Get Single User By ID
        /// </summary>
        /// <returns>Get an User</returns>
        /// <response code="404">If user id not found</response> 
        [Authorize]
        [HttpGet ("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById (int id) {
            var user = await _mediator.Send (new GetSingleUserQuery (id));
            if (user == null)
                return NotFound ();
            return Ok (user);
        }

        /// <summary>
        /// Creates a New User
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
        /// <returns>A newly created User Item</returns>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If any of the field is null</response> 
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateUser (User user) {
            var userResponse = await _mediator.Send (new CreateUserCommand (user));
            return Ok (userResponse);
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
        /// <returns>A newly updated User Item</returns>
        /// <response code="200">Returns the newly updated user</response>
        /// <response code="400">If any of the field is null</response> 
        /// <response code="404">If user id not found</response> 
        [Authorize]
        [HttpPut ("{id}", Name = "UpdateUser")]
        public async Task<IActionResult> UpdateUser (int id, User user) {
            var userSearchByID = await _mediator.Send (new GetSingleUserQuery (id));
            if (userSearchByID == null)
                return NotFound ();

            var userResponse = await _mediator.Send (new UpdateUserCommand (user));
            return Ok (userResponse);
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <returns>Deleted User Item</returns>
        /// <response code="200">Returns the newly deleted user</response>
        /// <response code="400">If any of the field is null</response> 
        /// <response code="404">If user id not found</response> 
        [Authorize]
        [HttpDelete ("{id}", Name = "DeleteUser")]
        public async Task<IActionResult> DeleteUser (int id) {
            var userSearchByID = await _mediator.Send (new GetSingleUserQuery (id));
            if (userSearchByID == null)
                return NotFound ();

            var userResponse = await _mediator.Send (new DeleteUserCommand (userSearchByID));
            return Ok (userResponse);
        }
    }
}