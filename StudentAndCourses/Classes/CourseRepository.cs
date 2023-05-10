using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAndCourses.Classes
{
   
    internal class CourseRepository
    {
        private readonly IDbConnection dbConnection;
        private SqlConnection connection;

        public CourseRepository(string con)
        {
            dbConnection = new SqlConnection(con);
        }

        public CourseRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public List<Course> SelectedCourse()
        {
            List<Course> course = dbConnection.Query<Course>("SELECT id_courses, CName, CTeacher FROM Courses").ToList();
            return course;
        }

        public void AddCourse(string name, string teacher)
        {
            dbConnection.Execute("INSERT INTO Courses (CName, CTeacher) VALUES (@Name, @Teacher)",
                                  new { Name = name, Teacher = teacher });
        }

        public void UpdateCourse(int id3, string name, string teacher)
        {
            string sql = "UPDATE Courses SET CName = @Name, CTeacher = @Teacher WHERE id_courses = @id_courses";

            dbConnection.Execute(sql, new { Name = name, Teacher = teacher, id_courses = id3 });
        }

        public void DeleteCourse(int id2)
        {
            string sqlQuery = "DELETE FROM Courses WHERE id_courses = @id_courses";
            dbConnection.Execute(sqlQuery, new { id_courses = id2 });
        }
    }
}
