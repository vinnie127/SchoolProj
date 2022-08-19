using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ITHSApi.Models;
using ITHSApi.Repository.IRepository;
using AutoMapper;
using ITHSApi.Models.DTO;
using ITHSApi.Models.DTO.TeacherDto;
using Microsoft.AspNetCore.Authorization;

namespace ITHSApi.Controllers
{
    [Route("api/Teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {


        private readonly ITeacherRepository _teacherRepo;
        private readonly IMapper _mapper;
        

        public TeacherController(ITeacherRepository teacherRepo, IMapper mapper)
        {
            _teacherRepo = teacherRepo;
            _mapper = mapper;



        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ShowAllTeacherDto>))]
        public IActionResult GetTeachers()
        {
            var objList = _teacherRepo.GetTeachers();

            var objDto = new List<ShowAllTeacherDto>();
            foreach (var obj in objList)
            {

                objDto.Add(_mapper.Map<ShowAllTeacherDto>(obj));

            }

            return Ok(objDto);
        }




        [HttpGet("{teacherId:int}", Name = "GetTeacher")]
        [ProducesResponseType(200, Type = typeof(ViewTeacherDto))]
        public IActionResult GetTeacher(int teacherId)
        {
            var objList = _teacherRepo.GetTeacher(teacherId);

            if (objList == null)
            {
                return NotFound();
            }

            var teacherObj = _mapper.Map<ViewTeacherDto>(objList);


            return Ok(teacherObj);
        }

       


        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Teacher))]
        public IActionResult CreateTeacher( [FromBody] CreateTeacherDto teacherDto)
        {

            if (teacherDto == null)
            {
                return BadRequest(ModelState);
            }

            
            var teacherObj = _mapper.Map<Teacher>(teacherDto);
            if (!_teacherRepo.CreateTeacher(teacherObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {teacherObj.FirstName}");
                return StatusCode(500, ModelState);
            }


            return CreatedAtRoute("GetTeacher", new { TeacherId = teacherObj.TeacherId }, teacherObj);
        }



        [HttpPatch("{teacherId:int}", Name = "UpdateTeacher")]
        public IActionResult UpdateTeacher( int teacherId, [FromBody] UpdateTeacherDto teacherDto)
        {

            if (teacherDto == null || teacherId != teacherDto.TeacherId)
            {
                return BadRequest(ModelState);
            }


            var teacherObj = _mapper.Map<Teacher>(teacherDto);

            if (!_teacherRepo.UpdateTeacher(teacherObj))
            {
                ModelState.AddModelError("", $"Something went wrong when Updating the record {teacherObj.FirstName}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }






        [HttpDelete("{teacherId:int}", Name = "DeleteTeacher")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteTeacher(int teacherId)
        {



            var teacherObj = _teacherRepo.GetTeacher(teacherId);
            if (!_teacherRepo.DeleteTeacher(teacherObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {teacherObj.FirstName}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }





        [HttpPost("[action]/{teacherId:int}")]
        public IActionResult AddCourse(int teacherId, int courseId)
        {

            if (teacherId == null || courseId == null)
            {
                return BadRequest(ModelState);
            }

            var teacherObj = _teacherRepo.AddToCourse(teacherId, courseId);
            //var studentObj = _mapper.Map<Student>(studentDto);

            //_studentRepo.AddCourse(studentObj);




            return Ok();
        }





        [HttpGet("[action]/{teacherId:int}")]
        [ProducesResponseType(200, Type = typeof(ViewTeacherCoursesDto))]
        public IActionResult GetCourses(int teacherId)
        {
            var objList = _teacherRepo.GetCourses(teacherId);

            if (objList == null)
            {
                return NotFound();
            }

            var objDto = new List<ViewTeacherCoursesDto>();

            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<ViewTeacherCoursesDto>(obj));
            }
            


            return Ok(objDto);
        }




    }
}
