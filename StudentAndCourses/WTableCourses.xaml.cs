using StudentAndCourses.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
    /// Interaction logic for WTableCourses.xaml
    /// </summary>
    public partial class WTableCourses : Window
    {
        private string conect = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
        private Course selectedCourse;
        public WTableCourses()
        {
            InitializeComponent();
            LoadCourse();
        }

        private void LoadCourse()
        {
            var courseRepository = new CourseRepository(conect);
            dataGridCourses.ItemsSource = courseRepository.SelectedCourse();
            dataGridCourses.DataContext = courseRepository;
        }
    }
}
