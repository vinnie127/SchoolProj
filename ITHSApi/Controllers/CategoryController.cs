
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ITHSApi.Models;
using ITHSApi.Repository.IRepository;

namespace ITHSApi.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {



        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;



        }


        [HttpGet("list")]
        [ProducesResponseType(200, Type = typeof(List<CategoryDto>))]
        public IActionResult GetCategories()
        {
            var objList = _categoryRepo.GetCategories();

           
            var objDto = new List<CategoryDto>();
            foreach (var obj in objList)
            {

                objDto.Add(_mapper.Map<CategoryDto>(obj));

            }


            return Ok(objDto);
        }


        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Category))]
        public IActionResult CreateCategory([FromBody] CategoryDto categoryDto)
        {

            if (categoryDto == null)
            {
                return BadRequest(ModelState);
            }

           
            var categoryObj = _mapper.Map<Category>(categoryDto);
            if (!_categoryRepo.CreateCategory(categoryObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {categoryObj.Name}");
                return StatusCode(500, ModelState);
            }


            return CreatedAtRoute("GetCategory", new { CategoryId = categoryObj.CategoryId }, categoryObj);
        }



        [HttpGet("{categoryId:int}", Name = "GetCategory")]
        [ProducesResponseType(200, Type = typeof(CategoryDto))]
        public IActionResult GetCategory(int id)
        {
            var objList = _categoryRepo.GetCategory(id);

            if (objList == null)
            {
                return NotFound();
            }

            var courseObj = _mapper.Map<CategoryDto>(objList);


            return Ok(courseObj);
        }




    }
}
