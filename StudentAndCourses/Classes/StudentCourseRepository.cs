using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //string query = "SELECT Students.SName + ' ' + Students.SSurname as [StudentName], Courses.CName as [CourseName] " +
            //    "FROM StudentCourse as SC " +
            //    "join Students on SC.id_students = Students.id_students " +
            //    "join Courses on SC.id_courses = Courses.id_courses";

            string query = "SELECT Students.SName + ' ' + Students.SSurname as [StudentName], Students.id_students, Courses.CName as [CourseName], Courses.id_courses " +
              "FROM StudentCourse as SC " +
              "join Students on SC.id_students = Students.id_students " +
              "join Courses on SC.id_courses = Courses.id_courses";

            List<StudentCourse> studentAndCourses = dbConnection.Query<StudentCourse>(query).ToList();
            return studentAndCourses;
        }

        public void AddStudentCourse(int id_students, int id_courses)
        {
            dbConnection.Execute("INSERT INTO StudentCourse (id_students, id_courses) VALUES (@id_students, @id_courses)",
                new { id_students, id_courses });
        }

        public void DeleteStudentCourse(int id_students2, int id_courses2)
        {
            string sqlQuery = "DELETE FROM StudentCourse WHERE id_students = @id_students and id_courses = @id_courses";
            dbConnection.Execute(sqlQuery, new { id_students = id_students2, id_courses = id_courses2 });
        }
    }
}
