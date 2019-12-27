using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseRegistrationApplication.Business;

namespace CourseRegistrationApplication.GUI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            textBoxUserId.Focus();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            User aUser = new User();
            aUser.UserID = Convert.ToInt32(textBoxUserId.Text);
            aUser.Password = textBoxPassword.Text;

            if (aUser.VerifyUser(aUser))
            {
                if (aUser.UserID == 11111 || aUser.UserID == 22222 || aUser.UserID == 33333 || aUser.UserID == 44444)
                {
                   //CourseRegistrationForm formChange = new CourseRegistrationForm();
                    //formChange.ShowDialog();
                    this.Close();
                }
               
            }
            else
            {
                MessageBox.Show("Username or Password is invalid!", "Denied!");
            }
        }

        private void buttonExit1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
