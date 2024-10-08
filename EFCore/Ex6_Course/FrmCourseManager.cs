﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Microsoft.EntityFrameworkCore;
using System.Linq;

using System.Diagnostics;


namespace Ex5_Course
{
    public partial class FrmCourseManager : Form
    {
        public FrmCourseManager()
        {
            InitializeComponent();
        }

        public class Logger
        {
            public static void Log(string message)
            {
                Console.WriteLine("EF Message: {0} ", message);
            }
        }

        private void FrmCourseManager_Load(object sender, EventArgs e)
        {
            using (CourseManagerModel db = new CourseManagerModel())
            {
                var result = MessageBox.Show("Do you really want to delete the existing database?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    txtDebug.Text += "Deleting DB...\r\n";
                    db.DeleteOldStore(); //<- my implementation, would be nice to implement Database.EnsureDeleted(); above
                    txtDebug.Text += "Deleted Ok\r\n";
                }
            }

            SeedData();

            DatabaseLoad_Enrolments();

            DatabaseLoad_Students();
            DatabaseLoad_Courses();

        }

        #region Student-CRUD

        private void lvStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lvStudents.SelectedItems.Count == 0)
            {
                lblStudent.Text = "";
                return;
            }

            int selectedIndex = lvStudents.SelectedIndices[0];

            ListViewItem lvItem = lvStudents.Items[selectedIndex];

            string sPk = lvItem.SubItems[0].Text;
            txtFirstname.Text = lvItem.SubItems[1].Text;
            txtLastname.Text = lvItem.SubItems[2].Text;

            lblStudent.Text = sPk + ":" + txtFirstname.Text + " " + txtLastname.Text;
        }
        void DatabaseLoad_Students()
        {

            lvStudents.Items.Clear();

            using (CourseManagerModel db = new CourseManagerModel())
            {

                DbSet<Student> people = db.Students;

                foreach (Student p in people)
                {
                    txtDebug.Text += String.Format("Loaded: {0} {1} {2} ", p.StudentId, p.FirstName, p.LastName) + "\r\n";

                    string[] row = { p.StudentId.ToString(), p.FirstName, p.LastName };
                    ListViewItem listViewItem = new ListViewItem(row);
                    lvStudents.Items.Add(listViewItem);
                }
            }
        }

        private void btnNewStudent_Click(object sender, EventArgs e)
        {

            txtDebug.Text = "btnNewStudent_Click()\r\n";

            using (CourseManagerModel db = new CourseManagerModel())
            {
                Student student = new Student();

                student.FirstName = txtFirstname.Text;
                student.LastName = txtLastname.Text;

                db.Students.Add(student);

                // This Exception handler helps to describe what went wrong with the EF database save.
                // It decodes why the data did not comply with defined database field structure. e.g too long or wrong type.
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException dbEx)
                {
                    // This Exception handler helps to describe what went wrong with the EF database save inner exception detail.
                    // It decodes why the data did not comply with defined database field structure. e.g too long or wrong type.
                    Exception raise = dbEx;
                    foreach (var entry in dbEx.Entries)
                    {
                        string message = $"Entity of type {entry.Entity.GetType().Name} in state {entry.State} could not be updated";
                        raise = new InvalidOperationException(message, raise);
                    }
                    throw raise;
                }
            }
            DatabaseLoad_Students();
        }
        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            //Get StudentId from Listview
            if (lvStudents.SelectedItems.Count == 0)
            {
                return;
            }

            int selectedIndex = lvStudents.SelectedIndices[0];
            ListViewItem lvItem = lvStudents.Items[selectedIndex];
            string sPk = lvItem.SubItems[0].Text;
            long pk = Convert.ToInt64(sPk);

            using (CourseManagerModel db = new CourseManagerModel())
            {
                // Get student to delete
                Student StudentToDelete = db.Students.First(s => s.StudentId == pk);

                if (StudentToDelete != null)
                {
                    // Delete 
                    db.Students.Remove(StudentToDelete);
                    db.SaveChanges();
                }
            }
            txtFirstname.Text = txtLastname.Text = "";
            DatabaseLoad_Students();
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            //Get StudentId from Listview
            if (lvStudents.SelectedItems.Count == 0)
            {
                return;
            }

            int selectedIndex = lvStudents.SelectedIndices[0];
            ListViewItem lvItem = lvStudents.Items[selectedIndex];
            string sPk = lvItem.SubItems[0].Text;
            long pk = Convert.ToInt64(sPk);

            using (CourseManagerModel db = new CourseManagerModel())
            {
                Student student = db.Students.SingleOrDefault(b => b.StudentId == pk);
                if (student != null)
                {
                    student.FirstName = txtFirstname.Text;
                    student.LastName = txtLastname.Text;

                    db.SaveChanges();
                }
            }
            DatabaseLoad_Students();

        }
        #endregion

        #region Courses-CRUD

        private void lvCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lvCourses.SelectedItems.Count == 0)
            {
                LblCourse.Text = "";
                return;
            }

            int selectedIndex = lvCourses.SelectedIndices[0];

            ListViewItem lvItem = lvCourses.Items[selectedIndex];

            string sPk = lvItem.SubItems[0].Text;
            txtCourseID.Text = lvItem.SubItems[1].Text;
            txtTitle.Text = lvItem.SubItems[2].Text;
            txtCredits.Text = lvItem.SubItems[3].Text;

            LblCourse.Text = sPk + ":" + txtCourseID.Text + " " + txtTitle.Text;
        }

        void DatabaseLoad_Courses()
        {

            lvCourses.Items.Clear();

            using (CourseManagerModel db = new CourseManagerModel())
            {
                DbSet<Course> courses = db.Courses;
                
                // System.InvalidOperationException: 'An error was generated for warning 'Microsoft.EntityFrameworkCore.Infrastructure.ManyServiceProvidersCreatedWarning':
                
                // More than twenty 'IServiceProvider' instances have been created for internal use by Entity Framework.
                
                // This is commonly caused by injection of a new singleton service instance into every DbContext instance.

                // For example, calling 'UseLoggerFactory' passing in a new instance each time--see https://go.microsoft.com/fwlink/?linkid=869049 for more details.
                // This may lead to performance issues, consider reviewing calls on 'DbContextOptionsBuilder' that may require new service providers to be built.
                // This exception can be suppressed or logged by passing event ID 'CoreEventId.ManyServiceProvidersCreatedWarning' to the 'ConfigureWarnings' method in
                // 'DbContext.OnConfiguring' or 'AddDbContext'.'

                int count = courses.Count();

                foreach (Course c in courses)
                {
                    txtDebug.Text += String.Format("Course Loaded: {0} {1} {2} {3} ", c.CourseId, c.CourseLabel, c.Title, c.Credits) + "\r\n";

                    //Note: Could do tuple
                    string[] row = { c.CourseId.ToString(), c.CourseLabel, c.Title, c.Credits.ToString() };
                    ListViewItem listViewItem = new ListViewItem(row);
                    lvCourses.Items.Add(listViewItem);
                }
                lvCourses.Refresh();
            }

        }

        private void btnNewCourse_Click(object sender, EventArgs e)
        {

            txtDebug.Text = "btnNewCourse_Click()\r\n";

            using (CourseManagerModel db = new CourseManagerModel())
            {
                Course course = new Course();

                course.CourseLabel = txtCourseID.Text;
                course.Title = txtTitle.Text;
                if (txtCredits.Text != "")
                    course.Credits = int.Parse(txtCredits.Text);

                db.Courses.Add(course);

                 try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException dbEx)
                {
                    // This Exception handler helps to describe what went wrong with the EF database save inner exception detail.
                    // It decodes why the data did not comply with defined database field structure. e.g too long or wrong type.
                    Exception raise = dbEx;
                    foreach (var entry in dbEx.Entries)
                    {
                        string message = $"Entity of type {entry.Entity.GetType().Name} in state {entry.State} could not be updated";
                        raise = new InvalidOperationException(message, raise);
                    }
                    throw raise;
                }
            }

            DatabaseLoad_Courses();
        }

        private void btnDeletCourse_Click(object sender, EventArgs e)
        {
            //Get PrimaryKey from Listview
            if (lvCourses.SelectedItems.Count == 0)
            {
                return;
            }

            int selectedIndex = lvCourses.SelectedIndices[0];
            ListViewItem lvItem = lvCourses.Items[selectedIndex];
            string sPk = lvItem.SubItems[0].Text;
            long pk = Convert.ToInt64(sPk);

            using (CourseManagerModel db = new CourseManagerModel())
            {
                // Get course to delete
                Course CourseToDelete = db.Courses.First(c => c.CourseId == pk);

                if (CourseToDelete != null)
                {
                    // Delete 
                    db.Courses.Remove(CourseToDelete);
                    db.SaveChanges();
                }
            }

            txtCourseID.Text = txtTitle.Text = txtCredits.Text = "";

            DatabaseLoad_Courses();
        }

        private void btnUpdateCourse_Click(object sender, EventArgs e)
        {
            //Get PrimaryKey from Listview
            if (lvCourses.SelectedItems.Count == 0)
            {
                return;
            }

            int selectedIndex = lvCourses.SelectedIndices[0];
            ListViewItem lvItem = lvCourses.Items[selectedIndex];
            string sPk = lvItem.SubItems[0].Text;
            long pk = Convert.ToInt64(sPk);

            using (CourseManagerModel db = new CourseManagerModel())
            {
                // Get course to delete
                Course CourseToUpdate = db.Courses.First(c => c.CourseId == pk);

                if (CourseToUpdate != null)
                {
                    CourseToUpdate.CourseLabel = txtCourseID.Text;
                    CourseToUpdate.Title = txtTitle.Text;
                    if (txtCredits.Text != "")
                        CourseToUpdate.Credits = int.Parse(txtCredits.Text);

                    db.SaveChanges();
                }
            }
            DatabaseLoad_Courses();
        }

        #endregion

        #region Enrollment-CRUD
        private void btnNewEnrol_Click(object sender, EventArgs e)
        {
            txtDebug.Text = "btnNewEnrol_Click()\r\n";

            //Get CourseId from Listview
            if (lvCourses.SelectedItems.Count == 0)
            {
                return;
            }

            int selectedIndex = lvCourses.SelectedIndices[0];
            ListViewItem lvItem = lvCourses.Items[selectedIndex];
            string sPk = lvItem.SubItems[0].Text;
            long CoursePk = Convert.ToInt64(sPk);

            //Get StudentId from Listview
            if (lvStudents.SelectedItems.Count == 0)
            {
                return;
            }

            selectedIndex = lvStudents.SelectedIndices[0];
            lvItem = lvStudents.Items[selectedIndex];
            sPk = lvItem.SubItems[0].Text;
            long StudentPk = Convert.ToInt64(sPk);

            using (CourseManagerModel db = new CourseManagerModel())
            {
               
                Course CourseToLink = db.Courses.First(c => c.CourseId == CoursePk);
                Student StudentToLink = db.Students.First(s => s.StudentId == StudentPk);

                Enrollment enroll = new Enrollment(CourseToLink, StudentToLink); // db.Enrollments.Create();
                                                                                 // enroll.Student = StudentToLink;
                                                                                 // enroll.Course = CourseToLink;
                int grade = int.TryParse(txtGrade.Text, out _) ? Convert.ToInt32(txtGrade.Text) : 0;
                enroll.Grade = Convert.ToInt32(grade);

                db.Enrollments.Add(enroll);

                // This Exception handler helps to describe what went wrong with the EF database save.
                // It decodes why the data did not comply with defined database field structure. e.g too long or wrong type.
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException dbEx)
                {
                    // This Exception handler helps to describe what went wrong with the EF database save inner exception detail.
                    // It decodes why the data did not comply with defined database field structure. e.g too long or wrong type.
                    Exception raise = dbEx;
                    foreach (var entry in dbEx.Entries)
                    {
                        string message = $"Entity of type {entry.Entity.GetType().Name} in state {entry.State} could not be updated";
                        raise = new InvalidOperationException(message, raise);
                    }
                    throw raise;
                }
            }

            DatabaseLoad_Enrolments();


        }
        private void btnEnrolmentUpdate_Click(object sender, EventArgs e)
        {
            txtDebug.Text = "btnEnrolmentUpdate_Click()\r\n";

            //Get CourseId from Listview
            if (lvEnrolments.SelectedItems.Count == 0)
            {
                txtDebug.Text = "NO Enrolment Selected? \r\n";
                return;
            }

            int selectedIndex = lvEnrolments.SelectedIndices[0];
            ListViewItem lvItem = lvEnrolments.Items[selectedIndex];


            string sPk = lvItem.SubItems[0].Text;
            long EnrolPk = Convert.ToInt64(sPk);

            using (CourseManagerModel db = new CourseManagerModel())
            {
                Enrollment EnrolToUpdate = db.Enrollments.First(en => en.EnrollmentId == EnrolPk);

                int grade = 0;
                var isNumeric = int.TryParse(txtGrade.Text, out grade);

                if (isNumeric)
                    EnrolToUpdate.Grade = int.Parse(txtGrade.Text);

                //With Bidirectional Association you can access child objects via parent, e.g Course.Student etc

                //Changes work in linked tables
                Student stu = EnrolToUpdate.Student;
                stu.FirstName = "Albert";
                stu.LastName = "Einstein";

                Course course = EnrolToUpdate.Course;
                course.Title = "Relativity";


                // This Exception handler helps to describe what went wrong with the EF database save.
                // It decodes why the data did not comply with defined database field structure. e.g too long or wrong type.
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException dbEx)
                {
                    // This Exception handler helps to describe what went wrong with the EF database save inner exception detail.
                    // It decodes why the data did not comply with defined database field structure. e.g too long or wrong type.
                    Exception raise = dbEx;
                    foreach (var entry in dbEx.Entries)
                    {
                        string message = $"Entity of type {entry.Entity.GetType().Name} in state {entry.State} could not be updated";
                        raise = new InvalidOperationException(message, raise);
                    }
                    throw raise;
                }
            }

            DatabaseLoad_Enrolments();
        }

        private void btnDeleteEnrol_Click(object sender, EventArgs e)
        {
            //Get PrimaryKey from Listview
            if (lvEnrolments.SelectedItems.Count == 0)
            {
                txtDebug.Text = "Cannot delete, NO Enrolment Selected ? \r\n";
                return;
            }

            int selectedIndex = lvEnrolments.SelectedIndices[0];
            ListViewItem lvItem = lvEnrolments.Items[selectedIndex];
            string sPk = lvItem.SubItems[0].Text;
            long pk = Convert.ToInt64(sPk);

            using (CourseManagerModel db = new CourseManagerModel())
            {
                // Get course to delete
                Enrollment EnrolToDelete = db.Enrollments.First(en => en.EnrollmentId == pk);

                if (EnrolToDelete != null)
                {
                    // Delete 
                    db.Enrollments.Remove(EnrolToDelete);
                    db.SaveChanges();
                }
            }

            txtGrade.Text = "";

            DatabaseLoad_Enrolments();
        }

        void DatabaseLoad_Enrolments()
        {
            lvEnrolments.Items.Clear();

            using (CourseManagerModel db = new CourseManagerModel())
            {
                DbSet<Enrollment> enrolments = db.Enrollments;


                //To Do Error - Reader not returning 

                
                foreach (Enrollment en in enrolments)
                {
                    string StudentName = "";
                    string CourseTitle = "";

                    Course course = en.Course;

                    //Debug.Assert(en.Student != null);
                    //Debug.Assert(en.Course != null);

                    if (course != null)
                        CourseTitle = course.Title;

                    Student stu = en.Student;

                    if (stu != null)
                        StudentName = stu.FirstName + " " + stu.LastName;

                    txtDebug.Text += $"Loaded: {en.EnrollmentId} {CourseTitle} {StudentName} {en.Grade.ToString()} ";

                    string[] row = { en.EnrollmentId.ToString(), CourseTitle, StudentName, en.Grade.ToString() };

                    ListViewItem listViewItem = new ListViewItem(row);
                    lvEnrolments.Items.Add(listViewItem);

                }
            }
        }


        #endregion


        #region GUIActions

        private void LbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get Record and Fill Textboxes

        }


        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {
            //Show Add 
        }


        private void txtLastname_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion


        #region SeedDb
        void SeedData()
        {
            using (CourseManagerModel db = new CourseManagerModel())
            {
                List<Student> students = new List<Student>
            {
            new Student{FirstName="Carson",LastName="Alexander" },//,EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstName="Meredith",LastName="Alonso"},//EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstName="Arturo",LastName="Anand"},//EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstName="Gytis",LastName="Barzdukas"},//EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstName="Yan",LastName="Li"},//EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstName="Peggy",LastName="Justice"},//EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{FirstName="Laura",LastName="Norman"},//EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstName="Nino",LastName="Olivetto"}//EnrollmentDate=DateTime.Parse("2005-09-01")}
            };

                foreach (Student s in students)
                {
                    Student stu = new Student();
                    stu.FirstName = s.FirstName;
                    stu.LastName = s.LastName;

                    db.Students.Add(stu);
                }

                // If you get Duplicate Key added error, and it looks like PK is not auto incrementing but you have an Id setup ok..?
                // The issue arised because ef uses a Pk naming convention that sometimes contends with table field naming.
                // That is..Watch out for duplication / usage of both 'Id' and 'IdTablename' when creating db structure
                // as ef uses Pk naming convention and detection.  Think of it kind of like reserved keywords?

                db.SaveChanges();

                List<Course> courses = new List<Course>
            {
            new Course{CourseLabel="1050",Title="Chemistry",Credits=3,},
            new Course{CourseLabel="4022",Title="Microeconomics",Credits=3,},
            new Course{CourseLabel="4041",Title="Macroeconomics",Credits=3,},
            new Course{CourseLabel="1045",Title="Calculus",Credits=4,},
            new Course{CourseLabel="3141",Title="Trigonometry",Credits=4,},
            new Course{CourseLabel="2021",Title="Composition",Credits=3,},
            new Course{CourseLabel="2042",Title="Literature",Credits=4,}
            };

                foreach (Course c in courses)
                {
                    Course course = new Course();
                    course.CourseLabel = c.CourseLabel;
                    course.Title = c.Title;
                    course.Credits = c.Credits;

                    db.Courses.Add(course);
                }

                db.SaveChanges();
            }

            DatabaseLoad_Students();
            DatabaseLoad_Courses();
            DatabaseLoad_Enrolments();
        }

        #endregion

        private void btnSeedData_Click(object sender, EventArgs e)
        {
            SeedData();
        }

        private void btnBiDirectionalUpdate_Click(object sender, EventArgs e)
        {
            //Get CourseId from Listview
            if (lvEnrolments.SelectedItems.Count == 0)
            {
                txtDebug.Text = "NO Enrolment Selected? \r\n";
                return;
            }

            int selectedIndex = lvEnrolments.SelectedIndices[0];
            ListViewItem lvItem = lvEnrolments.Items[selectedIndex];

            string sPk = lvItem.SubItems[0].Text;
            long EnrolPk = Convert.ToInt64(sPk);

            using (CourseManagerModel db = new CourseManagerModel())
            {
                Enrollment EnrolToUpdate = db.Enrollments.First(en => en.EnrollmentId == EnrolPk);

                int grade = 0;
                var isNumeric = int.TryParse(txtGrade.Text, out grade);

                if (isNumeric)
                    EnrolToUpdate.Grade = int.Parse(txtGrade.Text);

                //With Bidirectional Association you can access child objects via parent, e.g Course.Student etc

                // We are working with Enrollment and with Bi Directional
                // Changes work in child -> parent via linked tables student and course
                Student stu = EnrolToUpdate.Student;
                stu.FirstName = "Albert";
                stu.LastName = "Einstein";

                //linked table course
                Course course = EnrolToUpdate.Course;
                course.Title = "Relativity";


                // This Exception handler helps to describe what went wrong with the EF database save.
                // It decodes why the data did not comply with defined database field structure. e.g too long or wrong type.
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException dbEx)
                {
                    // This Exception handler helps to describe what went wrong with the EF database save inner exception detail.
                    // It decodes why the data did not comply with defined database field structure. e.g too long or wrong type.
                    Exception raise = dbEx;
                    foreach (var entry in dbEx.Entries)
                    {
                        string message = $"Entity of type {entry.Entity.GetType().Name} in state {entry.State} could not be updated";
                        raise = new InvalidOperationException(message, raise);
                    }
                    throw raise;
                }
            }

            DatabaseLoad_Students();
            DatabaseLoad_Courses();
            DatabaseLoad_Enrolments();
        }
    }
}