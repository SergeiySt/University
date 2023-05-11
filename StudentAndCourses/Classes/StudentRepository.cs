using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using Dapper;
using System.Windows.Media.Imaging;
using System.Windows.Controls.Primitives;

namespace StudentAndCourses.Classes
{
    internal class StudentRepository
    {
        private readonly IDbConnection dbConnection;

        public StudentRepository(string con2)
        {
            dbConnection = new SqlConnection(con2);
        }

        public List<Student> SelectedStudents()
        {
                List<Student> students = dbConnection.Query<Student>("SELECT id_students, SName, SSurname, SAge FROM Students").ToList();
                return students;
        }

        public bool IsStudentExist(string name, string surname)
        {
            string sqlQuery = "SELECT COUNT(*) FROM Students WHERE SName = @Name AND SSurname = @Surname";
            int count = dbConnection.QuerySingle<int>(sqlQuery, new { Name = name, Surname = surname });
            return count > 0;
        }

        public void AddStudent(string name, string surname, int age)
        {
            if (IsStudentExist(name, surname))
            {
                System.Windows.MessageBox.Show("Студент із таким ім'ям та прізвищем вже існує", "Увага", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Warning);
                return;
            }

            dbConnection.Execute("INSERT INTO Students (SName, SSurname, SAge) VALUES (@Name, @Surname, @Age)",
                                  new { Name = name, Surname = surname, Age = age });
            System.Windows.MessageBox.Show("Студента успішно додано", "Успішно", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Information);
        }

        public void UpdateStudent(int id, string name, string surname, int age)
        {
            string sql = "UPDATE Students SET SName = @Name, SSurname = @Surname, SAge = @Age WHERE id_students = @id_students";

            dbConnection.Execute(sql, new { Name = name, Surname = surname, Age = age, id_students = id });
            System.Windows.MessageBox.Show("Дані успішно оновлені", "Успішно", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Information);
        }

        public void DeleteStudent(int id)
        {
            try
            {
                if (System.Windows.MessageBox.Show("Ви точно хочете видалити студента?", "Попередження", MessageBoxButton.YesNo, (MessageBoxImage)MessageBoxIcon.Question) == MessageBoxResult.Yes)
                {
                    string sqlQuery = "DELETE FROM Students WHERE id_students = @id_students";
                    dbConnection.Execute(sqlQuery, new { id_students = id });
                    System.Windows.MessageBox.Show("Успішно видалено", "Успішно", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    System.Windows.MessageBox.Show("Студент не може бути видалений, тому що є пов'язані записи у списку призначених курсів", "Попередження", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Warning);
                }
            }
        }

        public List<Student> SearchStudents(string name, string surname)
        {
            string sqlQuery = "SELECT * FROM Students WHERE SName LIKE '%' + @Name + '%' AND SSurname LIKE '%' + @Surname + '%'";
            List<Student> students = dbConnection.Query<Student>(sqlQuery, new { Name = name, Surname = surname }).ToList();
            if (students.Count == 0)
            {
                System.Windows.MessageBox.Show("Студенти з таким ім'ям та прізвищем не знайдені", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return students;
        }
    }
}

