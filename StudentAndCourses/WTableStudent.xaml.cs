using OfficeOpenXml;
using StudentAndCourses.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Interaction logic for WTableStudent.xaml
    /// </summary>
    /// 
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

        private void buttonExport_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile()))
                {
                    writer.WriteLine("Id,Ім'я,Прізвище,Вік");

                    for (int i = 0; i < dataGridStudent.Items.Count; i++)
                    {
                        var row = dataGridStudent.Items[i] as Student;
                        writer.WriteLine($"{row.id_students},{row.SName},{row.SSurname},{row.SAge}");
                    }
                }
            }
        }

        private void buttonExportExcel_Click(object sender, RoutedEventArgs e)
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Студенти");
            worksheet.Cells[1, 1].Value = "Id";
            worksheet.Cells[1, 2].Value = "Ім'я";
            worksheet.Cells[1, 3].Value = "Прізвище";
            worksheet.Cells[1, 4].Value = "Вік";

            for (int i = 0; i < dataGridStudent.Items.Count; i++)
            {
                var row = dataGridStudent.Items[i] as Student;
                worksheet.Cells[i + 2, 1].Value = row.id_students;
                worksheet.Cells[i + 2, 2].Value = row.SName;
                worksheet.Cells[i + 2, 3].Value = row.SSurname;
                worksheet.Cells[i + 2, 4].Value = row.SAge;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Stream stream = saveFileDialog.OpenFile();
                package.SaveAs(stream);
                stream.Close();
            }
        }
    }
}
