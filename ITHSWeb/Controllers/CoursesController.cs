using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ITHSWeb.Models;
using ITHSWeb.Models.ViewModel;
using ITHSWeb.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;

namespace ITHSWeb.Controllers
{


    public class CoursesController : Controller
    {

        private readonly ICourseRepository _cRepo;
        private readonly IStudentRepository _studentRepo;

        public CoursesController(ICourseRepository cRepo, IStudentRepository student)
        {
            _cRepo = cRepo;
            _studentRepo = student;
        }




        public async Task<IActionResult> Index()
        {
            var CourseList = await _cRepo.GetAllAsync(SD.CourseAPIPath);


            //Vi lade in denna när vi lade till authorization
            //if (CourseList == null)
            //{

            //    return NotFound();
            //}


            return View("Index", CourseList);


            //Tidigare 
            //return View(new Course() { });
        }


        //GET , this will update and create
        [Authorize(Roles="admin")]
        public async Task<IActionResult> Update(int? id)
        {
            Course course = new Course();

            if (id == null)
            {
                return View(course);
            }

            course = await _cRepo.GetAsync(SD.CourseAPIPath, id.GetValueOrDefault());

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
           


        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Course course)
        {


            if (ModelState.IsValid)
            {

                if (course.Id == 0)
                {
                    await _cRepo.CreateAsync(SD.CourseAPIPath, course);
                }


                else
                {
                    await _cRepo.UpdateAsync(SD.CourseAPIPath + course.Id, course);
                }


                return RedirectToAction(nameof(Index));
            }

            return View(course);


        }







        public async Task<IActionResult> GetAllCourse()
        {

            return Json(new { data = await _cRepo.GetAllAsync(SD.CourseAPIPath) });
            //return Json(new { data = await _cRepo.GetStudents(SD.StudentsInCourseAPIPath, 30) });

        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _cRepo.DeleteAsync(SD.CourseAPIPath, id);
            if (status)
            {
                return Json(new { success = true, message = "Delete Successful" });
            }

            return Json(new { success = false, message = "Delete not Successful" });

        }


        public async Task<IActionResult> Studenterna(int id)
        {

            var result = await _cRepo.GetStudents(SD.StudentsInCourseAPIPath, id);

            var resultJson = Json(new { data = result.FirstOrDefault()?.student });

            return resultJson;

        }




        public async Task<IActionResult> StudentList(int id)
        {
            var StudentList = new ListStudentVM();
            ViewBag.Id = id;
            return View(StudentList);
        }



    }
}

