using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationApplication.DataAccess;
using System.Windows.Forms;

namespace CourseRegistrationApplication.Business
{
   public class Course
    {
        private string courseNumber;
        private string courseTitle;
        private int duration;
        private string prerequisite;

        public string CourseNumber { get => courseNumber; set => courseNumber = value; }
        public string CourseTitle { get => courseTitle; set => courseTitle = value; }
        public int Duration { get => duration; set => duration = value; }
        public string Prerequisite { get => prerequisite; set => prerequisite = value; }

        public List<Course> GetCoursesList()
        {
            return CourseDB.GetCourses();
        }
    }
}
