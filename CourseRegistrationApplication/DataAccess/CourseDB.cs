using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CourseRegistrationApplication.Business;

namespace CourseRegistrationApplication.DataAccess
{
    public static class CourseDB
    {
        public static List<Course> GetCourses()
        {
            List<Course> listCourse = new List<Course>();
            SqlConnection connection = UtilityDB.ConnectDB();
            SqlCommand selectCmd = new SqlCommand("SELECT * FROM Courses", connection);
            SqlDataReader reader = selectCmd.ExecuteReader();
            Course course;
            while (reader.Read())
            {
                course = new Course();
                course.CourseNumber = reader["CourseCode"].ToString();
                course.CourseTitle = reader["CourseTitle"].ToString();
                course.Duration = Convert.ToInt32(reader["Duration"]);
                course.Prerequisite = reader["Prerequisite"].ToString();
                listCourse.Add(course);
            }
            connection.Close();
            return listCourse;
        }
    }
}
