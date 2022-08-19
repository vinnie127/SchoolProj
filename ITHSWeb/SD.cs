namespace ITHSWeb
{
    public static class SD
    {


        public static string APIBaseUrl = "https://localhost:7111/";

        public static string CourseAPIPath = APIBaseUrl + "api/Course/";
        public static string StudentsInCourseAPIPath = APIBaseUrl + "api/Course/GetStudents/";

        public static string StudentAPIPath = APIBaseUrl + "api/Student/";
        public static string CoursesInStudentAPIPath = APIBaseUrl + "api/Student/GetCourses/";

        public static string TeacherAPIPath = APIBaseUrl + "api/Teacher/";
        public static string CoursesInTeacherAPIPath = APIBaseUrl + "api/Teacher/GetCourses/";

        public static string AccountAPIPath = APIBaseUrl + "api/Users/";








    }
}
