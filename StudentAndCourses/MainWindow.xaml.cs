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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace StudentAndCourses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString;
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Если подключение успешно, открываем вторую форму

                    WService wService = new WService();
                    wService.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    // Если произошла ошибка, выводим сообщение об ошибке
                    MessageBox.Show("Помилка підключення: " + ex.Message);
                    
                    timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(5);
                    timer.Tick += Timer_Tick;
                    timer.Start();
                }
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Не вдалося підключитися до сервера", "Примітка", MessageBoxButton.OK, MessageBoxImage.Information);
            timer.Stop();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard labelAnimation = FindResource("LabelAnimation") as Storyboard;
            Storyboard imageAnimation = FindResource("ImageAnimation") as Storyboard;
            Storyboard buttonAnimation = FindResource("ButtonAnimation") as Storyboard;

            labelAnimation.Begin(label1);
            labelAnimation.Begin(label2);
            imageAnimation.Begin(pictureBox);
            buttonAnimation.Begin(buttonExit);
        }
    }
}
