using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace StudentAndCourses.Classes
{
    internal class StudentCourseRepository
    {
        private readonly IDbConnection dbConnection;
       
        public StudentCourseRepository(string con)
        {
            dbConnection = new SqlConnection(con);
        }

        public List<StudentCourse> SelectedSAC()
        {
            string query = "SELECT Students.SName + ' ' + Students.SSurname as [StudentName], Students.id_students, Courses.CName as [CourseName], Courses.id_courses " +
              "FROM StudentCourse as SC " +
              "join Students on SC.id_students = Students.id_students " +
              "join Courses on SC.id_courses = Courses.id_courses";

            List<StudentCourse> studentAndCourses = dbConnection.Query<StudentCourse>(query).ToList();
            return studentAndCourses;
        }

        public void AddStudentCourse(int id_students, int id_courses)
        {
            var existingRecord = dbConnection.QueryFirstOrDefault<StudentCourse>("SELECT * FROM StudentCourse WHERE " +
               "id_students = @id_students AND id_courses = @id_courses", new { id_students, id_courses });

            if (existingRecord != null)
            {
                System.Windows.MessageBox.Show("Такий курс для студента вже існує.", "Увага", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Warning);
                return;
            }

            dbConnection.Execute("INSERT INTO StudentCourse (id_students, id_courses) VALUES (@id_students, @id_courses)", new { id_students, id_courses });
        }
      
        public void DeleteStudentCourse(int id_students2, int id_courses2)
        {
            if (System.Windows.MessageBox.Show("Ви точно хочете видалити призначений курс для студента?", "Попередження", MessageBoxButton.YesNo, (MessageBoxImage)MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                string sqlQuery = "DELETE FROM StudentCourse WHERE id_students = @id_students and id_courses = @id_courses";
                dbConnection.Execute(sqlQuery, new { id_students = id_students2, id_courses = id_courses2 });
                System.Windows.MessageBox.Show("Успішно видалено", "Успішно", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Information);
            }
        }
    }
}
