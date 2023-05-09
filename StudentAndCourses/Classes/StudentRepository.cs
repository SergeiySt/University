using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace StudentAndCourses.Classes
{
    internal class StudentRepository
    {
        private readonly IDbConnection dbConnection;

        public  StudentRepository(string con)
        {
            dbConnection = new SqlConnection(con);
        }
        public List<Student> SelectedStudents()
        {
                List<Student> students = dbConnection.Query<Student>("SELECT id_students, SName, SSurname, SAge FROM Students").ToList();
                return students;
        }

        public void AddStudent(string name, string surname, int age)
        {
            dbConnection.Execute("INSERT INTO Students (SName, SSurname, SAge) VALUES (@Name, @Surname, @Age)",
                                  new { Name = name, Surname = surname, Age = age });
        }

        public void UpdateStudent(int id, string name, string surname, int age)
        {
            string sql = "UPDATE Students SET SName = @Name, SSurname = @Surname, SAge = @Age WHERE id_students = @id_students";

            dbConnection.Execute(sql, new { Name = name, Surname = surname, Age = age, id_students = id });
        }

        public void DeleteStudent(int id)
        {
            string sqlQuery = "DELETE FROM Students WHERE id_students = @id_students";
            dbConnection.Execute(sqlQuery, new { id_students = id });
        }
    }
}

