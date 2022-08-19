using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ITHSApi.Models;
using ITHSApi.Repository.IRepository;
using AutoMapper;
using ITHSApi.Models.DTO.CourseDto;
using ITHSApi.Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace ITHSApi.Controllers
{
    
    [Route("api/Course")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class CourseController : ControllerBase
    {


        private readonly ICourseRepository _courseRepo;
        private readonly IMapper _mapper;
        

        public CourseController(ICourseRepository courseRepo, IMapper mapper)
        {
            _courseRepo = courseRepo;
            _mapper = mapper;



        }


      
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ViewCourseDetailsDto>))]
        public IActionResult GetCourses()
        {
            var objList = _courseRepo.GetCourses();

            var objDto = new List<ViewCourseDetailsDto>();
            foreach (var obj in objList)
            {

                objDto.Add(_mapper.Map<ViewCourseDetailsDto>(obj));

            }

            return Ok(objDto);
        }



        [HttpGet("{id:int}", Name = "GetCourse")]
        [ProducesResponseType(200, Type = typeof(ViewCourseDetailsDto))]
        public IActionResult GetCourse(int id)
        {
            var objList = _courseRepo.GetCourse(id);

            if (objList == null)
            {
                return NotFound();
            }

            var courseObj = _mapper.Map<ViewCourseDetailsDto>(objList);


            return Ok(courseObj);
        }




        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CreateCourseDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCourse( [FromBody] CreateCourseDto courseDto)
        {

            if (courseDto == null)
            {
                return BadRequest(ModelState);
            }

            
            var courseObj = _mapper.Map<Course>(courseDto);
            if (!_courseRepo.CreateCourse(courseObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {courseObj.Title}");
                return StatusCode(500, ModelState);
            }


            return CreatedAtRoute("GetCourse", new { Id = courseObj.Id }, courseObj);
        }



     
        [HttpPatch("{id:int}", Name = "UpdateCourse")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCourse(int id, [FromBody] UpdateCourseDto courseDto)
        {

            if (courseDto == null || id != courseDto.Id)
            {
                return BadRequest(ModelState);
            }


            var courseObj = _mapper.Map<Course>(courseDto);

            if (!_courseRepo.UpdateCourse(courseObj))
            {
                ModelState.AddModelError("", $"Something went wrong when Updating the record {courseObj.Title}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }





        [HttpDelete("{id:int}", Name = "DeleteCourse")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCourse(int id)
        {

            

            var courseObj = _courseRepo.GetCourse(id);
            if (!_courseRepo.DeleteCourse(courseObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {courseObj.Title}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }






        [HttpGet("[action]/{id:int}")]
        [ProducesResponseType(200, Type = typeof(StudentsInCourseDto))]
        public IActionResult GetStudents(int id)
        {
            var objList = _courseRepo.GetStudents(id);

            if (objList == null)
            {
                return NotFound();
            }

            var objDto = new List<StudentsInCourseDto>();

            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<StudentsInCourseDto>(obj));
            }



            return Ok(objDto);
        }




    }
}
