﻿using StudentAndCourses.Classes;
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

        private StudentRepository studentRepository;

        private int selectedCourseId;
        private int selectedStudentId;

        private int selectedCourseId_2;
        private int selectedStudentId_2;

      
        public WService()
        {
           InitializeComponent();
            studentRepository = new StudentRepository(conect);
            LoadStudent();
            LoadCourse();
            LoadStudentCourse();
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

            }
        }

        
        private void buttonAddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNameStudent.Text))
            {
                System.Windows.MessageBox.Show("Введіть ім'я студента", "Примітка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxSurNameStudent.Text))
            {
                System.Windows.MessageBox.Show("Введіть прізвище студента", "Примітка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxAgeStudent.Text))
            {
                System.Windows.MessageBox.Show("Введіть вік студента", "Примітка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var studentRepository = listViwStudents.DataContext as StudentRepository;
            if (studentRepository != null)
            {
                studentRepository.AddStudent(textBoxNameStudent.Text, textBoxSurNameStudent.Text, int.Parse(textBoxAgeStudent.Text));
                listViwStudents.ItemsSource = studentRepository.SelectedStudents();
            }

            ClearTextBoxStudent();
        }

        private void buttonUpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            if (listViwStudents.SelectedItems.Count == 0)
            {
                System.Windows.MessageBox.Show("Виберіть студента для оновлення записів.", "Увага", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Warning);
                return;
            }

            var studentRepository = listViwStudents.DataContext as StudentRepository;
            if (studentRepository != null && selectedStudent != null)
            {
                studentRepository.UpdateStudent(selectedStudent.id_students, textBoxNameStudent.Text, textBoxSurNameStudent.Text, Convert.ToInt32(textBoxAgeStudent.Text));
                listViwStudents.ItemsSource = studentRepository.SelectedStudents();
            }
            ClearTextBoxStudent();
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
            ClearTextBoxStudent();
        }


        private void listViwCource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCourse = (Course)listViwCource.SelectedItem;
            if (selectedCourse != null)
            {
                textBoxNameCourse.Text = selectedCourse.CName;
                textBoxTeacher.Text = selectedCourse.CTeacher;

                selectedCourseId = selectedCourse.id_courses;
            }
        }

        private void buttonAddCourse_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNameCourse.Text))
            {
                System.Windows.MessageBox.Show("Введіть назву курса", "Примітка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxTeacher.Text))
            {
                System.Windows.MessageBox.Show("Введіть прізвище та ініціали викладача", "Примітка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

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

        private void ClearTextBoxStudent()
        {
            textBoxNameStudent.Text = "";
            textBoxSurNameStudent.Text = "";
            textBoxAgeStudent.Text = "";
        }

        private void buttonUpdateCourse_Click(object sender, RoutedEventArgs e)
        {
            if (listViwCource.SelectedItems.Count == 0)
            {
                System.Windows.MessageBox.Show("Виберіть курс для оновлення записів.", "Увага", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Warning);
                return;
            }

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
            if (listViwCource.SelectedItems.Count == 0)
            {
                System.Windows.MessageBox.Show("Виберіть курс для видалення.", "Увага", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Warning);
                return;
            }

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
            if (selectedStudentId == 0 && selectedCourseId == 0)
            {
                System.Windows.MessageBox.Show("Спочатку виберіть студента і курс перед призначенням", "Увага", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Warning);
                return;
            }

            var studentCourseRepository = listViwStudentCourseRepository.DataContext as StudentCourseRepository;
            if (studentCourseRepository != null)
            {
                studentCourseRepository.AddStudentCourse(selectedStudentId, selectedCourseId);
                listViwStudentCourseRepository.ItemsSource = studentCourseRepository.SelectedSAC();
            }
        }

        private void buttonDeleteStudentCourse_Click(object sender, RoutedEventArgs e)
        {
            if (listViwStudentCourseRepository.SelectedItems.Count == 0)
            {
                System.Windows.MessageBox.Show("Спочатку виберіть студента якому призначено курс для видалення", "Увага", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Warning);
                return;
            }
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
                selectedStudentId_2 = selectedStudentCourse.id_students;
                selectedCourseId_2 = selectedStudentCourse.id_courses;
            }
        }

        private void buttonExportDateStudent_Click(object sender, RoutedEventArgs e)
        {

        }
        private void buttonFindStudent_Click_1(object sender, RoutedEventArgs e)
        {
            string name = textBoxNameStudent.Text.Trim();
            string surname = textBoxSurNameStudent.Text.Trim();
           

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
            {
                    List<Student> students = studentRepository.SearchStudents(name, surname);
                    listViwStudents.ItemsSource = students;
            }
            else
            {
                System.Windows.MessageBox.Show("Введіть ім'я та прізвище для пошуку", "Попередження", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadStudent();
        }
    }
}
