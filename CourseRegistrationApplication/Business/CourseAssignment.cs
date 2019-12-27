using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseRegistrationApplication.DataAccess;
namespace CourseRegistrationApplication.Business
{
    public class CourseAssignment
    {
        private int studentID;
        private string courseNumber;
        private DateTime assignedDate;

        public int StudentID { get => studentID; set => studentID = value; }
        public string CourseNumber { get => courseNumber; set => courseNumber = value; }
        public DateTime AssignedDate { get => assignedDate; set => assignedDate = value; }

        public void AssignedCourse(CourseAssignment ca)
        {
            CourseAssignmentDB.SaveCourseAssignment(ca);
        }

        public void DisplayCourses (int studentId,ListView listCourse)
        {
            CourseAssignmentDB.ListCourseByStudent(studentId, listCourse);
        }
        
        public bool IsDuplicateAssignment(CourseAssignment ca)

        {
            return CourseAssignmentDB.IsDuplicateAssignment(ca);
        }
    }
}
