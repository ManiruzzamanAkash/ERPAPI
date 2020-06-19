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
        [HttpGet]
        public async Task<IActionResult> GetAllUsers () {
            var allUsers = await _mediator.Send (new GetAllUserQuery ());
            return Ok (allUsers);
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
        [HttpPost]
        public async Task<IActionResult> CreateUser (User user) {
            var userResponse = await _mediator.Send (new CreateUserCommand (user));
            return Ok (userResponse);
        }

        // [Authorize]
        // [HttpGet("{id}", Name = "GetCategoryById")]
        // public ActionResult<CategoryReadDto> GetCategoryById(int id)
        // {
        //     var categoryItem = _repository.GetCategoryById(id);
        //     if (categoryItem == null)
        //         return NotFound();
        //     return Ok(_mapper.Map<CategoryReadDto>(categoryItem));
        // }

        // [Authorize]
        // // POST api/categories
        // [HttpPost]
        // public ActionResult<CategoryCreateDto> CreateCategory(CategoryCreateDto categoryCreateDto)
        // {
        //     var categoryModel = _mapper.Map<Category>(categoryCreateDto);
        //     _repository.CreateCategory(categoryModel);
        //     _repository.SaveChanges();

        //     var categoryReadDto = _mapper.Map<CategoryReadDto>(categoryModel);

        //     return CreatedAtRoute(nameof(GetCategoryById), new { Id = categoryReadDto.Id }, categoryReadDto);

        //     //return Ok(commandReadDto);
        // }

        // [Authorize]
        // POST api/categories
        // [HttpPost]
        // public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryOrderRequest request)
        // {
        //     var categoryModel = _mapper.Map<Category>(categoryCreateDto);
        //     _repository.CreateCategory(categoryModel);
        //     _repository.SaveChanges();

        //     var categoryReadDto = _mapper.Map<CategoryReadDto>(categoryModel);

        //     return CreatedAtRoute(nameof(GetCategoryById), new { Id = categoryReadDto.Id }, categoryReadDto);

        //     //return Ok(commandReadDto);
        // }

        // [Authorize]
        // // PUT api/categories
        // [HttpPut("{id}")]
        // public ActionResult UpdateCategory(int id, CategoryCreateDto CategoryUpdateDto)
        // {
        //     var categorydModelFromRepo = _repository.GetCategoryById(id);
        //     if (categorydModelFromRepo == null)
        //     {
        //         return NotFound();
        //     }

        //     _mapper.Map(CategoryUpdateDto, categorydModelFromRepo);

        //     _repository.UpdateCategory(categorydModelFromRepo);

        //     _repository.SaveChanges();

        //     var categoryReadItem = _repository.GetCategoryById(id);
        //     if (categoryReadItem == null)
        //         return NoContent();
        //     return Ok(_mapper.Map<CategoryReadDto>(categoryReadItem));
        // }

        // [Authorize]
        // // PATCH api/categories
        // [HttpPatch("{id}")]
        // public ActionResult PartialUpdateCategory(int id, JsonPatchDocument<CategoryUpdateDto> patchDoc)
        // {
        //     var categoryModelFromRepo = _repository.GetCategoryById(id);
        //     if (categoryModelFromRepo == null)
        //     {
        //         return NotFound();
        //     }

        //     var categoryToPatch = _mapper.Map<CategoryUpdateDto>(categoryModelFromRepo);
        //     patchDoc.ApplyTo(categoryToPatch, ModelState);

        //     if (!TryValidateModel(categoryToPatch))
        //     {
        //         return ValidationProblem(ModelState);
        //     }

        //     _mapper.Map(categoryToPatch, categoryModelFromRepo);
        //     _repository.UpdateCategory(categoryModelFromRepo);
        //     _repository.SaveChanges();

        //     var categoryReadItem = _repository.GetCategoryById(id);
        //     if (categoryReadItem == null)
        //         return NoContent();
        //     return Ok(_mapper.Map<CategoryReadDto>(categoryReadItem));
        // }

        // [Authorize]
        // // DELeTE api/categories
        // [HttpDelete("{id}")]
        // public ActionResult DeleteCategory(int id)
        // {
        //     var categoryModelFromRepo = _repository.GetCategoryById(id);
        //     if (categoryModelFromRepo == null)
        //     {
        //         return NotFound();
        //     }

        //     _repository.DeleteCategory(categoryModelFromRepo);
        //     _repository.SaveChanges();

        //     return NoContent();
        // }
    }
}