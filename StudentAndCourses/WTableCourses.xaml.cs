using OfficeOpenXml;
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

        private void buttonExportCSV_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile()))
                {
                    writer.WriteLine("Id,Назва курса,Викладач");

                    for (int i = 0; i < dataGridCourses.Items.Count; i++)
                    {
                        var row = dataGridCourses.Items[i] as Course;
                        writer.WriteLine($"{row.id_courses},{row.CName},{row.CTeacher}");
                    }
                }
            }
            System.Windows.MessageBox.Show("Дані успішно експортовано", "Успішно", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Information);
        }

        private void buttonExportExcel_Click(object sender, RoutedEventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Студенти");
            worksheet.Cells[1, 1].Value = "Id";
            worksheet.Cells[1, 2].Value = "Назва курса";
            worksheet.Cells[1, 3].Value = "Викладач";


            for (int i = 0; i < dataGridCourses.Items.Count; i++)
            {
                var row = dataGridCourses.Items[i] as Course;
                worksheet.Cells[i + 2, 1].Value = row.id_courses;
                worksheet.Cells[i + 2, 2].Value = row.CName;
                worksheet.Cells[i + 2, 3].Value = row.CTeacher;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Stream stream = saveFileDialog.OpenFile();
                package.SaveAs(stream);
                stream.Close();
            }
            System.Windows.MessageBox.Show("Дані успішно експортовано", "Успішно", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Information);
        }
    }
}
