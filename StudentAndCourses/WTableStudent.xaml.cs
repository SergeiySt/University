using StudentAndCourses.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentAndCourses
{
    /// <summary>
    /// Interaction logic for WTableStudent.xaml
    /// </summary>
    public partial class WTableStudent : Window
    {
        private string conect = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
        private Student selectedStudent;
        public WTableStudent()
        {
            InitializeComponent();
            LoadStudent();

        }

        private void LoadStudent()
        {
            var studentRepository = new StudentRepository(conect);
            dataGridStudent.ItemsSource = studentRepository.SelectedStudents();
            dataGridStudent.DataContext = studentRepository;

        }
    }
}
