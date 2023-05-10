using StudentAndCourses.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentAndCourses
{
    /// <summary>
    /// Interaction logic for WService.xaml
    /// </summary>
    public partial class WService : Window
    {
        private string conect = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;

        private Student selectedStudent;
        private Course selectedCourse;
        private StudentCourse selectedStudentCourse;

        

        private int selectedCourseId;
        private int selectedStudentId;

        private int selectedCourseId_2;
        private int selectedStudentId_2;

        //private StudentRepository studentRepository;
        //private CourseRepository courseRepository;
        //private StudentCourseRepository studentCourseRepository;

        public WService()
        {
           InitializeComponent();

            //var connection = new SqlConnection(conect);

            LoadStudent();
            LoadCourse();
            LoadStudentCourse();

            //studentRepository = new StudentRepository(connection);
            //listViwStudents.ItemsSource = studentRepository.SelectedStudents();
            //DataContext = studentRepository;

            //courseRepository = new CourseRepository(connection);
            //listViwCource.ItemsSource = courseRepository.SelectedCourse();
            //DataContext = courseRepository;

            //studentCourseRepository = new StudentCourseRepository(connection);
            //listViwStudentCourseRepository.ItemsSource = studentCourseRepository.SelectedSAC();
            //DataContext = studentCourseRepository;
        }

        private void LoadStudent()
        {
            var studentRepository = new StudentRepository(conect);
            listViwStudents.ItemsSource = studentRepository.SelectedStudents();
            listViwStudents.DataContext = studentRepository;

        }

        private void LoadCourse()
        {
            var courseRepository = new CourseRepository(conect);
            listViwCource.ItemsSource = courseRepository.SelectedCourse();
            listViwCource.DataContext = courseRepository;
        }

        private void LoadStudentCourse()
        {
            var studentCourseRepository = new StudentCourseRepository(conect);
            listViwStudentCourseRepository.ItemsSource = studentCourseRepository.SelectedSAC();
            listViwStudentCourseRepository.DataContext = studentCourseRepository;
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedStudent = (Student)listViwStudents.SelectedItem;
            if (selectedStudent != null)
            {

                textBoxNameStudent.Text = selectedStudent.SName;
                textBoxSurNameStudent.Text = selectedStudent.SSurname;
                textBoxAgeStudent.Text = selectedStudent.SAge.ToString();

                selectedStudentId = selectedStudent.id_students;

                student.Text = selectedStudent.id_students.ToString();
            }
        }

        private void buttonAddStudent_Click(object sender, RoutedEventArgs e)
        {
            var studentRepository = listViwStudents.DataContext as StudentRepository;
            if (studentRepository != null)
            {
                studentRepository.AddStudent(textBoxNameStudent.Text, textBoxSurNameStudent.Text, int.Parse(textBoxAgeStudent.Text));
                listViwStudents.ItemsSource = studentRepository.SelectedStudents();
            }
        }

        private void buttonUpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            var studentRepository = listViwStudents.DataContext as StudentRepository;
            if (studentRepository != null && selectedStudent != null)
            {
                studentRepository.UpdateStudent(selectedStudent.id_students, textBoxNameStudent.Text, textBoxSurNameStudent.Text, Convert.ToInt32(textBoxAgeStudent.Text));
                listViwStudents.ItemsSource = studentRepository.SelectedStudents();
            }
        }

        private void buttonDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if (listViwStudents.SelectedItems.Count == 0)
            {
                System.Windows.MessageBox.Show("Виберіть студента для видалення.", "Увага", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Warning);
                return;
            }

            var studentRepository = listViwStudents.DataContext as StudentRepository;
            if (studentRepository != null && listViwStudents.SelectedItem != null)
            {
                var selectedStudent = listViwStudents.SelectedItem as Student;
                studentRepository.DeleteStudent(selectedStudent.id_students);
                listViwStudents.ItemsSource = studentRepository.SelectedStudents();
            }
        }


        private void listViwCource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCourse = (Course)listViwCource.SelectedItem;
            if (selectedCourse != null)
            {
                textBoxNameCourse.Text = selectedCourse.CName;
                textBoxTeacher.Text = selectedCourse.CTeacher;

                selectedCourseId = selectedCourse.id_courses;

                course.Text = selectedCourse.id_courses.ToString();
            }
        }

        private void buttonAddCourse_Click(object sender, RoutedEventArgs e)
        {
            var courseRepository = listViwCource.DataContext as CourseRepository;
            if (courseRepository != null)
            {
                courseRepository.AddCourse(textBoxNameCourse.Text, textBoxTeacher.Text);
                listViwCource.ItemsSource = courseRepository.SelectedCourse();
            }

            ClearTextBoxCourse();
        }

        private void ClearTextBoxCourse()
        {
            textBoxNameCourse.Text = "";
            textBoxTeacher.Text = "";
        }

        private void buttonUpdateCourse_Click(object sender, RoutedEventArgs e)
        {
            var courseRepository = listViwCource.DataContext as CourseRepository;
            if (courseRepository != null && selectedCourse != null)
            {
                courseRepository.UpdateCourse(selectedCourse.id_courses, textBoxNameCourse.Text, textBoxTeacher.Text);
                listViwCource.ItemsSource = courseRepository.SelectedCourse();
            }

            ClearTextBoxCourse();
        }

        private void buttonDeleteCourse_Click(object sender, RoutedEventArgs e)
        {
            var courseRepository = listViwCource.DataContext as CourseRepository;
            if(courseRepository != null && listViwCource.SelectedItem != null)
            {
                var selectedCourse = listViwCource.SelectedItem as Course;
                courseRepository.DeleteCourse(selectedCourse.id_courses);
                listViwCource.ItemsSource = courseRepository.SelectedCourse();
            }

            ClearTextBoxCourse();
        }

        private void ButtonAddStudentCourse(object sender, RoutedEventArgs e)
        {
            var studentCourseRepository = listViwStudentCourseRepository.DataContext as StudentCourseRepository;
            if (studentCourseRepository != null)
            {
                studentCourseRepository.AddStudentCourse(selectedStudentId, selectedCourseId);
                listViwStudentCourseRepository.ItemsSource = studentCourseRepository.SelectedSAC();
            }
        }

        private void buttonDeleteStudentCourse_Click(object sender, RoutedEventArgs e)
        {
            var studentCourseRepository = listViwStudentCourseRepository.DataContext as StudentCourseRepository;
            if (studentCourseRepository != null && listViwStudentCourseRepository.SelectedItem != null)
            {
                studentCourseRepository.DeleteStudentCourse(selectedStudentId_2, selectedCourseId_2);
                listViwStudentCourseRepository.ItemsSource = studentCourseRepository.SelectedSAC();
            }
        }

        private void listViwStudentCourseRepository_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            selectedStudentCourse = (StudentCourse)listViwStudentCourseRepository.SelectedItem;
            if (selectedStudentCourse != null)
            {
                t.Text = selectedStudentCourse.id_students.ToString();
                y.Text = selectedStudentCourse.id_courses.ToString();

                selectedStudentId_2 = selectedStudentCourse.id_students;
                selectedCourseId_2 = selectedStudentCourse.id_courses;
            }
        }

        private void buttonExportDateStudent_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
