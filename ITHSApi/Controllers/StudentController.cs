using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ITHSApi.Models;
using ITHSApi.Repository.IRepository;
using AutoMapper;
using ITHSApi.Models.DTO.Student;
using ITHSApi.Models.DTO;
using ITHSApi.Models;


namespace ITHSApi.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {


        private readonly IStudentRepository _studenRepo;
        private readonly IMapper _mapper;
        

        public StudentController(IStudentRepository studentRepo, IMapper mapper)
        {
            _studenRepo = studentRepo;
            _mapper = mapper;



        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ShowAllStudentsDto>))]
        public IActionResult GetStudents()
        {
            var objList = _studenRepo.GetStudents();

            var objDto = new List<ShowAllStudentsDto>();
            foreach (var obj in objList)
            {

                objDto.Add(_mapper.Map<ShowAllStudentsDto>(obj));

            }

            return Ok(objDto);
        }




        [HttpGet("{studentId:int}", Name = "GetStudent")]
        [ProducesResponseType(200, Type = typeof(ViewStudentDto))]
        public IActionResult GetStudent(int studentId)
        {
            var objList = _studenRepo.GetStudent(studentId);

            if (objList == null)
            {
                return NotFound();
            }

            var studentObj = _mapper.Map<ViewStudentDto>(objList);


            return Ok(studentObj);
        }

       


        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Student))]
        public IActionResult CreateStudent( [FromBody] CreateStudentDto studentDto)
        {

            if (studentDto == null)
            {
                return BadRequest(ModelState);
            }

            //if (_studenRepo.NationalParkExists(nationalParkDto.Name))
            //{
            //    ModelState.AddModelError("", "National park exists already");
            //    return StatusCode(404, ModelState);
            //}
            var studentObj = _mapper.Map<Student>(studentDto);
            if (!_studenRepo.CreateStudent(studentObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {studentObj.Name}");
                return StatusCode(500, ModelState);
            }


            return CreatedAtRoute("GetStudent", new { StudentId = studentObj.StudentId }, studentObj);
        }



        [HttpPatch("{studentId:int}", Name = "UpdateStudent")]
        public IActionResult UpdateStudent(int studentId, [FromBody] UpdateStudentDto studentDto)
        {

            if (studentDto == null || studentId != studentDto.StudentId)
            {
                return BadRequest(ModelState);
            }


            var studentObj = _mapper.Map<Student>(studentDto);

            if (!_studenRepo.UpdateStudent(studentObj))
            {
                ModelState.AddModelError("", $"Something went wrong when Updating the record {studentObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }






        [HttpDelete("{studentId:int}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteStudent(int studentId)
        {



            var studentObj = _studenRepo.GetStudent(studentId);
            if (!_studenRepo.DeleteStudent(studentObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {studentObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }





        [HttpPost("[action]/{studentId:int}")]
        public IActionResult AddCourse(int studentId, int courseId)
        {

            if (studentId == null || courseId == null)
            {
                return BadRequest(ModelState);
            }

            var studentObj = _studenRepo.AddCourse(studentId, courseId);
          



            return Ok();
        }



        [HttpGet("[action]/{studentId:int}")]
        [ProducesResponseType(200, Type = typeof(ShowAllStudentsDto))]
        public IActionResult GetCourses(int studentId)
        {
            var objList = _studenRepo.GetCourses(studentId);

            if (objList == null)
            {
                return NotFound();
            }

            var objDto = new List<ShowAllStudentsDto>();

            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<ShowAllStudentsDto>(obj));
            }
            


            return Ok(objDto);
        }




    }
}
