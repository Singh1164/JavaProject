using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationApplication.DataAccess;
using System.Windows.Forms;


namespace CourseRegistrationApplication.Business
{
   public class Student
    {
        private int studentID;
        private string firstName;
        private string lastName;
        private double homePhone;
        private string email;

        public int StudentID { get => studentID; set => studentID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public double HomePhone { get => homePhone; set => homePhone = value; }
        public string Email { get => email; set => email = value; }

        public List<Student> GetStudentList()
        {
            return (StudentDB.GetRecordList());
        }
    }
}
