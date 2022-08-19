using AutoMapper;
using ITHSApi.Models;
using ITHSApi.Models.DTO;
using ITHSApi.Models.DTO.CourseDto;
using ITHSApi.Models.DTO.LogIn;
using ITHSApi.Models.DTO.Student;
using ITHSApi.Models.DTO.TeacherDto;


namespace ITHSApi.SchoolMapper
{
    public class SchoolMapping : Profile
    {


        public SchoolMapping()
        {


            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Student, ShowAllStudentsDto>().ReverseMap();
            CreateMap<Student, ViewStudentClassesDto>().ReverseMap();
            CreateMap<Student, ViewStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();

            CreateMap<Course, CreateCourseDto>().ReverseMap();
            CreateMap<Course, StudentsInCourseDto>().ReverseMap();
            CreateMap<Course, TeachersInCourseDto>().ReverseMap();
            CreateMap<Course, UpdateCourseDto>().ReverseMap();
            CreateMap<Course, ViewCourseDetailsDto>().ReverseMap();
            CreateMap<Course, ViewCourseCategoryDto>().ReverseMap();
            

            CreateMap<Teacher, CreateTeacherDto>().ReverseMap();
            CreateMap<Teacher, ShowAllTeacherDto>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherDto>().ReverseMap();
            CreateMap<Teacher, ViewTeacherCoursesDto>().ReverseMap();
            CreateMap<Teacher, ViewTeacherDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();


            CreateMap<User, LoginRequestDto>().ReverseMap();

        }




    }
}
