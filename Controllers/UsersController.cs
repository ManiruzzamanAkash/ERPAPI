using System.Collections.Generic;
using System.Threading.Tasks;
using APIFuelStation.QueryBus.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace APIFuelStation.Controllers {
    // api/categories
    [Route ("/api/[controller]")]
    [ApiController]
    public class UsersContrller : ControllerBase {
        private readonly IMediator _mediator;

        public UsersContrller (IMediator mediator) {
            this._mediator = mediator;
        }

        // private readonly ICategoryRepo _repository;
        // private readonly IMapper _mapper;

        // public UsersContrller(ICategoryRepo repository, IMapper mapper)
        // {
        //     _repository = repository;
        //     _mapper = mapper;
        // }

        // [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers () {
            var allUsers = await _mediator.Send (new GetAllUserQuery ());
            return Ok (allUsers);
        }

        // [Authorize]
        // [HttpGet]
        // public async Task<IActionResult> GetAllCategories()
        // {
        //     // var queries = new GetAllCategoryQuery();
        // }

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