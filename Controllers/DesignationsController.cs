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
    public class DesignationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DesignationsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // [Authorize]
        /// <summary>
        /// Get All of the Designations List
        /// </summary>
        /// <returns>A New Designation </returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllDesignations()
        {
            var allDesignations = await _mediator.Send(new GetAllDesignationQuery());
            return Ok(allDesignations);
        }

        // [Authorize]
        /// <summary>
        /// Get Single Designation By ID
        /// </summary>
        /// <returns>Get an Designation</returns>
        /// <response code="404">If user id not found</response> 
        [Authorize]
        [HttpGet("{id}", Name = "GetDesignationById")]
        public async Task<IActionResult> GetDesignationById(int id)
        {
            var user = await _mediator.Send(new GetSingleDesignationQuery(id));
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        /// <summary>
        /// Creates a New Designation
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///         "id": 0,
        ///         "name": "Designation 1",
        ///         "code": "DEP12",
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly created Designation Item</returns>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If any of the field is null</response> 
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateDesignation(Designation user)
        {
            var userResponse = await _mediator.Send(new CreateDesignationCommand(user));
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
        /// <returns>A newly updated Designation Item</returns>
        /// <response code="200">Returns the newly updated user</response>
        /// <response code="400">If any of the field is null</response> 
        /// <response code="404">If user id not found</response> 
        [Authorize]
        [HttpPut("{id}", Name = "UpdateDesignation")]
        public async Task<IActionResult> UpdateDesignation(int id, Designation user)
        {
            var designationSearchByID = await _mediator.Send(new GetSingleDesignationQuery(id));
            if (designationSearchByID == null)
                return NotFound();

            var userResponse = await _mediator.Send(new UpdateDesignationCommand(user));
            return Ok(userResponse);
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <returns>Deleted Designation Item</returns>
        /// <response code="200">Returns the newly deleted user</response>
        /// <response code="400">If any of the field is null</response> 
        /// <response code="404">If user id not found</response> 
        [Authorize]
        [HttpDelete("{id}", Name = "DeleteDesignation")]
        public async Task<IActionResult> DeleteDesignation(int id)
        {
            var designationSearchByID = await _mediator.Send(new GetSingleDesignationQuery(id));
            if (designationSearchByID == null)
                return NotFound();

            var userResponse = await _mediator.Send(new DeleteDesignationCommand(designationSearchByID));
            return Ok(userResponse);
        }
    }
}