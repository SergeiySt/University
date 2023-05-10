using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace StudentAndCourses.Classes
{
   
    internal class CourseRepository
    {
        private readonly IDbConnection dbConnection;
        public CourseRepository(string con)
        {
            dbConnection = new SqlConnection(con);
        }

        public List<Course> SelectedCourse()
        {
            List<Course> course = dbConnection.Query<Course>("SELECT id_courses, CName, CTeacher FROM Courses").ToList();
            return course;
        }

        public bool IsCourseExist(string name, string teacher)
        {
            string sqlQuery = "SELECT COUNT(*) FROM Courses WHERE CName = @Name AND CTeacher = @Teacher";
            int count = dbConnection.QuerySingle<int>(sqlQuery, new { Name = name, Teacher = teacher });
            return count > 0;
        }

        public void AddCourse(string name, string teacher)
        {
            if (IsCourseExist(name, teacher))
            {
                System.Windows.MessageBox.Show("Курс з таким викладачем вже існує", "Увага", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Warning);
                return;
            }
            dbConnection.Execute("INSERT INTO Courses (CName, CTeacher) VALUES (@Name, @Teacher)",
                                  new { Name = name, Teacher = teacher });
            System.Windows.MessageBox.Show("Курс успішно додано", "Успішно", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Information);
        }

        public void UpdateCourse(int id3, string name, string teacher)
        {
            string sql = "UPDATE Courses SET CName = @Name, CTeacher = @Teacher WHERE id_courses = @id_courses";

            dbConnection.Execute(sql, new { Name = name, Teacher = teacher, id_courses = id3 });
            System.Windows.MessageBox.Show("Дані успішно оновлені", "Успішно", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Information);
        }

        public void DeleteCourse(int id2)
        {
            try
            {
                if (System.Windows.MessageBox.Show("Ви точно хочете видалити курс?", "Попередження", MessageBoxButton.YesNo, (MessageBoxImage)MessageBoxIcon.Question) == MessageBoxResult.Yes)
                {
                    string sqlQuery = "DELETE FROM Courses WHERE id_courses = @id_courses";
                    dbConnection.Execute(sqlQuery, new { id_courses = id2 });
                    System.Windows.MessageBox.Show("Успішно видалено", "Успішно", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    System.Windows.MessageBox.Show("Цей курс не може бути видалений, тому що є пов'язані записи у списку призначених курсів", "Попередження", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Warning);
                }
            }
        }
    }
}
