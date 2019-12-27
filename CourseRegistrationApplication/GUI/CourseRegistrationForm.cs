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

namespace CourseRegistrationApplication
{
    public partial class Form1 : Form
    {
        List<Student> listStudent;
        List<Course> listCourse;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Student aStudent = new Student();
            listStudent = new List<Student>();
            listStudent = aStudent.GetStudentList();
            foreach (Student a_Student in listStudent)
            {
                comboBoxStudent.Items.Add(a_Student.StudentID);
            }

            Course aCourse = new Course();
            listCourse = new List<Course>();
            listCourse = aCourse.GetCoursesList();
            foreach (Course item in listCourse)
            {
                comboBoxCourse.Items.Add(item.CourseNumber);
            }

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBoxStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int StudentId = Convert.ToInt32(comboBoxStudent.Text);
            Student aStudent = listStudent.Find(t => t.StudentID == StudentId);
           labelStudent.Text = aStudent.FirstName + "," + aStudent.LastName;
        }

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            string courseNumber = comboBoxCourse.Text;
            Course aCourse = listCourse.Find(c => c.CourseNumber == courseNumber);
            labelCourse.Text = aCourse.CourseTitle + " , " + aCourse.Duration;
        }

        private void buttonAssignCourse_Click(object sender, EventArgs e)
        {
            CourseAssignment ca = new CourseAssignment();
            ca.StudentID = Convert.ToInt32(comboBoxStudent.Text);
            ca.CourseNumber = comboBoxCourse.Text;
            ca.AssignedDate = Convert.ToDateTime(dateTimePicker1.Text);
            if (!ca.IsDuplicateAssignment(ca))
            {
                ca.AssignedCourse(ca);
                MessageBox.Show("Course assigned successfully", "Confirmation");
            }
            else
            {
                MessageBox.Show("This Course has been assigned already", "Warning");
            }
        }

        private void buttonListCourse_Click(object sender, EventArgs e)
        {
            CourseAssignment ca = new CourseAssignment();
            listViewCourse.Items.Clear();
            ca.DisplayCourses(Convert.ToInt32(comboBoxStudent.Text), listViewCourse);
        }

        private void buttonListStudents_Click(object sender, EventArgs e)
        {
            CourseAssignment ca = new CourseAssignment();
            listViewStudents.Items.Clear();
            //ca.DisplayStudents(comboBoxCourse.Text, listViewStudents);
        }
    }
}
