using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAndCourses.Classes
{
    internal class StudentCourse
    {
        public int id_students { get; set; }
        public int id_courses { get; set; }

        public string StudentName { get; set; }
        public string CourseName { get; set; }
    }
}
