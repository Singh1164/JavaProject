using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationApplication.Business;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CourseRegistrationApplication.DataAccess
{
    public static class CourseAssignmentDB
    {
        public static void SaveCourseAssignment(CourseAssignment courseAssigned)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = connDB;
            sqlCmd.CommandText = "INSERT INTO CourseAssignment (StudentID, CourseNumber, AssignedDate) " +
                                    "VALUES (@StudentID, @CourseNumber,@AssignedDate)";
            sqlCmd.Parameters.AddWithValue("@StudentId", courseAssigned.StudentID);
            sqlCmd.Parameters.AddWithValue("@CourseNumber", courseAssigned.CourseNumber);
            sqlCmd.Parameters.AddWithValue("@AssignedDate", courseAssigned.AssignedDate);

            sqlCmd.ExecuteNonQuery();
            connDB.Close();
        }

        public static void ListCourseByStudent(int studentId, ListView listCourse)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            string sqlSelect = "SELECT  C.CourseNumber, C.CourseTitle, C.Duration, C.Prerequisite" +
                                   "FROM Courses C, CourseAssignments CA " +
                                    "WHERE C.CourseNumber = CA.CourseNumber " +
                                    "AND CA.StudentID = " + studentId;
            SqlCommand cmd = new SqlCommand(sqlSelect, connDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem listItem = new ListViewItem(reader["CourseNumber"].ToString());
                    listItem.SubItems.Add(reader["CourseTitle"].ToString());
                    listItem.SubItems.Add(reader["Duration"].ToString());
                    listItem.SubItems.Add(reader["Prerequisite"].ToString());
                    listCourse.Items.Add(listItem);
                }
            }
            else
            {
                MessageBox.Show("No course assigned to this teacher.", "No Course Assigned");
            }

        }
        public static bool IsDuplicateAssignment(CourseAssignment ca)
        {
            bool duplicate = false;
            SqlConnection connDB = UtilityDB.ConnectDB();
            string sqlSelect = "SELECT * FROM CourseAssignment";
            SqlCommand command = new SqlCommand(sqlSelect, connDB);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if ((ca.StudentID == Convert.ToInt32(reader["StudentID"])) &&
                        (ca.CourseNumber == reader["CourseNumber"].ToString()) )
                        
                    {
                        duplicate = true;
                        break;
                    }
                }
            }
            connDB.Close();
            return duplicate;
        }
    }
}
