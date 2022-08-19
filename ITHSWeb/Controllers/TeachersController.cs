using Microsoft.AspNetCore.Mvc;
using ITHSWeb.Models;
using ITHSWeb.Models.ViewModel;
using ITHSWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITHSWeb.Controllers
{


    public class TeachersController : Controller
    {

        private readonly ICourseRepository _cRepo;
        private readonly ITeacherRepository _teacherRepo;

        public TeachersController(ICourseRepository cRepo, ITeacherRepository teacherRepo)
        {
            _cRepo = cRepo;
            _teacherRepo = teacherRepo;
        }

        


        public async Task<IActionResult> Index()
        {
           
            return View(new Teacher() { } );

        }


        //GET , this will update and create
        public async Task<IActionResult> Update(int? id)
        {


            Teacher obj = new Teacher();
            

            if (id == null)
            {
                //this will be true for Insert/Create
                return View(obj);
            }

            //Flow will come here for update
            obj = await _teacherRepo.GetAsync(SD.TeacherAPIPath, id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);



            

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Teacher obj)
        {


            if (ModelState.IsValid)
            {

                if (obj.TeacherId == 0)
                {
                    await _teacherRepo.CreateAsync(SD.TeacherAPIPath, obj);
                }


                else
                {
                    await _teacherRepo.UpdateAsync(SD.TeacherAPIPath + obj.TeacherId, obj);
                }


                return RedirectToAction(nameof(Index));
            }

            else
            {


                Teacher objVM = new Teacher();
               
                return View(objVM);
            }


        }







        public async Task<IActionResult> GetAllTeacher()
        {

            return Json(new { data = await _teacherRepo.GetAllAsync(SD.TeacherAPIPath) });


        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _teacherRepo.DeleteAsync(SD.TeacherAPIPath, id);
            if (status)
            {
                return Json(new { success = true, message = "Delete Successful" });
            }

            return Json(new { success = false, message = "Delete not Successful" });

        }


        public async Task<IActionResult> Courses(int id)
        {

            var result = await _teacherRepo.CoursesInTeacher(SD.CoursesInTeacherAPIPath, id);

            var resultJson = Json(new { data = result.FirstOrDefault()?.courses });

            return resultJson;

        }




        public async Task<IActionResult> CourseList(int id)
        {
            var CourseList = new CoursesInTeacherVM();
            ViewBag.id = id;
            return View(CourseList);
        }






    }
}

