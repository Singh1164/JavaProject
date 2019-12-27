using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationApplication.DataAccess;
using System.Windows.Forms;

namespace CourseRegistrationApplication.Business
{
 public class User
    {
        private int userID;
        private string password;

        public int UserID { get => userID; set => userID = value; }
        public string Password { get => password; set => password = value; }

        public bool VerifyUser(User aUser)
        {
            return DataAccess.UserDB.IsValidUser(aUser);
        }
    }
}
