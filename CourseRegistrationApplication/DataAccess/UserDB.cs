using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using CourseRegistrationApplication.Business;

namespace CourseRegistrationApplication.DataAccess
{
   public static class UserDB
    {
       

            public static bool IsValidUser(User aUser)
            {

                using (SqlConnection connectionDb = UtilityDB.ConnectDB())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connectionDb;
                    string sqlSelect = "SELECT UserName,Password FROM Users " +
                                       "WHERE UserName = @UserName AND Password = @Password";
                    cmd.CommandText = sqlSelect;
                    cmd.Parameters.AddWithValue("@UserName", aUser.UserID);
                    cmd.Parameters.AddWithValue("@Password", aUser.Password);
                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    if (sqlReader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }


            }
        }
    }

