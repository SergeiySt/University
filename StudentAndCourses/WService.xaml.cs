using StudentAndCourses.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public WService()
        {
            InitializeComponent();

            var studentRepository = new StudentRepository(conect);
            listViwStudents.ItemsSource = studentRepository.SelectedStudents();
            DataContext = studentRepository;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //MainWindow mainWindow = new MainWindow();   
            //mainWindow.Show();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if(listViwStudents.SelectedItem != null)
            //{
            //    if(listViwStudents.SelectedItem is Student selectedStudent)
            //    {
            //        textBoxNameStudent.Text = selectedStudent.SName;
            //        textBoxSurNameStudent.Text = selectedStudent.SSurname;
            //        textBoxAgeStudent.Text = selectedStudent.SAge.ToString();
            //    }
            //}
            selectedStudent = (Student)listViwStudents.SelectedItem;
            if (selectedStudent != null)
            {
                textBoxNameStudent.Text = selectedStudent.SName;
                textBoxSurNameStudent.Text = selectedStudent.SSurname;
                textBoxAgeStudent.Text = selectedStudent.SAge.ToString();
            }
        }

        private void buttonAddStudent_Click(object sender, RoutedEventArgs e)
        {
            var studentRepository = DataContext as StudentRepository;
            if (studentRepository != null)
            {
                studentRepository.AddStudent(textBoxNameStudent.Text, textBoxSurNameStudent.Text, int.Parse(textBoxAgeStudent.Text));
                listViwStudents.ItemsSource = studentRepository.SelectedStudents();
            }
        }

        private void buttonUpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            var studentRepository = DataContext as StudentRepository;
            if (studentRepository != null && selectedStudent != null)
            {
                studentRepository.UpdateStudent(selectedStudent.id_students, textBoxNameStudent.Text, textBoxSurNameStudent.Text, Convert.ToInt32(textBoxAgeStudent.Text));
                listViwStudents.ItemsSource = studentRepository.SelectedStudents();
            }
        }

        private void buttonDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            var studentRepository = DataContext as StudentRepository;
            if (studentRepository != null && listViwStudents.SelectedItem != null)
            {
                var selectedStudent = listViwStudents.SelectedItem as Student;
                studentRepository.DeleteStudent(selectedStudent.id_students);
                listViwStudents.ItemsSource = studentRepository.SelectedStudents();
            }
        }

        private void buttonExportDateStudent_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
