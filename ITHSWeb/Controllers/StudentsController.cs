using Microsoft.AspNetCore.Mvc;
using ITHSWeb.Models;
using ITHSWeb.Models.ViewModel;
using ITHSWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITHSWeb.Controllers
{


    public class StudentsController : Controller
    {

        private readonly ICourseRepository _cRepo;
        private readonly IStudentRepository _studentRepo;

        public StudentsController(ICourseRepository cRepo, IStudentRepository studentRepo)
        {
            _cRepo = cRepo;
            _studentRepo = studentRepo;
        }

        


        public async Task<IActionResult> Index()
        {
            //var StudentList = await _studentRepo.GetAllAsync(SD.StudentAPIPath);

            //return View("Index", StudentList);


            ////Tidigare 
            ////return View(new Course() { });
            ///
            return View(new Student() { } );

        }




        public async Task<IActionResult> ListOfCourses(int id)
        {
            Student student = new Student();
            student = await _studentRepo.GetAsync(SD.StudentAPIPath, id);





            return View(student);

        }


        //GET , this will update and create
        public async Task<IActionResult> Update(int? id)
        {


            StudentsVM obj = new StudentsVM()
            {

                Student = new Student()

             };

            if (id == null)
            {
                //this will be true for Insert/Create
                return View(obj);
            }

            //Flow will come here for update
            obj.Student = await _studentRepo.GetAsync(SD.StudentAPIPath, id.GetValueOrDefault());
            if (obj.Student == null)
            {
                return NotFound();
            }
            return View(obj);



            //IEnumerable<Course> courseList = await _cRepo.GetAllAsync(SD.CourseAPIPath);

            //StudentsVM objVM = new StudentsVM()
            //{
            //    CourseList = courseList.Select(i => new SelectListItem
            //    {
            //        Text = i.Title,
            //        Value = i.Id.ToString()
            //    }),
            //    Student = new Student()
            //};

            ////Create
            //if (id == null)
            //{
            //    return View(objVM);
            //}

            ////Update
            //objVM.Student = await _studentRepo.GetAsync(SD.StudentAPIPath, id.GetValueOrDefault());
            //if (objVM.Student == null)
            //{
            //    return NotFound();
            //}


            //return View(objVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(StudentsVM obj)
        {


            if (ModelState.IsValid)
            {

                if (obj.Student.StudentId == 0)
                {
                    await _studentRepo.CreateAsync(SD.StudentAPIPath, obj.Student);
                }


                else
                {
                    await _studentRepo.UpdateAsync(SD.StudentAPIPath + obj.Student.StudentId, obj.Student);
                }


                return RedirectToAction(nameof(Index));
            }

            else
            {
                

                StudentsVM objVM = new StudentsVM()
                {
                    
                    Student = obj.Student
                };
                return View(objVM);
            }


        }







        public async Task<IActionResult> GetAllStudent()
        {

            return Json(new { data = await _studentRepo.GetAllAsync(SD.StudentAPIPath) });


        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _studentRepo.DeleteAsync(SD.StudentAPIPath, id);
            if (status)
            {
                return Json(new { success = true, message = "Delete Successful" });
            }

            return Json(new { success = false, message = "Delete not Successful" });

        }



        public async Task<IActionResult> Courses(int id)
        {

            var result = await _cRepo.GetCoursesFromStudent(SD.CoursesInStudentAPIPath, id);

            var resultJson = Json(new { data = result.FirstOrDefault()?.courses });

            return resultJson;

        }




        public async Task<IActionResult> CourseList(int id)
        {
            var CourseList = new CourseListVM();
            ViewBag.id = id;
            return View(CourseList);
        }







    }
}

