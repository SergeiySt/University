using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentAndCourses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString;
        public MainWindow()
        {
            InitializeComponent();
            //connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
        }

        private void buttonConnect_Click(object sender, RoutedEventArgs e)
        {
            //string serverName = textBoxNameServer.Text;
            //string dataBase = textBoxDataBase.Text;
            //string username = textBoxUser.Text;
            //string password = textBoxPassword.Text;

            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //config.AppSettings.Settings["ServerAddress"].Value = serverName;
            //config.AppSettings.Settings["DataBase"].Value = dataBase;
            //if (!string.IsNullOrEmpty(username))
            //{
            //    config.AppSettings.Settings["User"].Value = username;
            //}
            //if (!string.IsNullOrEmpty(password))
            //{
            //    config.AppSettings.Settings["Password"].Value = password;
            //}
            //config.Save(ConfigurationSaveMode.Modified);


            //string connectionString;
            //if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            //{
            //    connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            //    connectionString = connectionString.Replace("${ServerAddress}", serverName)
            //                                         .Replace("${DataBase}", dataBase)
            //                                         .Replace("${User}", username)
            //                                         .Replace("${Password}", password);
            //}
            //else
            //{
            //    connectionString = ConfigurationManager.ConnectionStrings["connectionString_2"].ConnectionString;
            //    connectionString = connectionString.Replace("${ServerAddress}", serverName)
            //                                         .Replace("${DataBase}", dataBase);
            //}

            //// Проверяем подключение к базе данных
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    try
            //    {
            //        connection.Open();
            //        // Если подключение успешно, открываем вторую форму
                    
            //        WService wService = new WService();
            //        wService.Show();
                    
            //    }
            //    catch (Exception ex)
            //    {
            //        // Если произошла ошибка, выводим сообщение об ошибке
            //        MessageBox.Show("Помилка підключення: " + ex.Message);
            //    }
            //}
            //this.Close();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            WService wService = new WService();
            wService.Show();
            this.Close();
        }
    }
}
