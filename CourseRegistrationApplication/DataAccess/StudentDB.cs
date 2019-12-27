using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationApplication.Business;
using System.Data.SqlClient;

namespace CourseRegistrationApplication.DataAccess
{
    public static class StudentDB
    {
        public static List<Student> GetRecordList()
        {
            List<Student> listStudent = new List<Student>();
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand selectCmd = new SqlCommand();
            selectCmd.Connection = connDB;
            selectCmd.CommandText = "SELECT * FROM Students1";
            SqlDataReader sqlReader = selectCmd.ExecuteReader();
            Student student;
            while (sqlReader.Read())
            {
                student = new Student();
                student.StudentID = Convert.ToInt32(sqlReader["StudentID"]);
                student.FirstName = sqlReader["FirstName"].ToString();
                student.LastName = sqlReader["LastName"].ToString();
                student.HomePhone = Convert.ToDouble(sqlReader["HomePhone"]);
                student.Email= sqlReader["Email"].ToString();
                listStudent.Add(student);
            }

            connDB.Close();
            return listStudent;
        }
    }
}
