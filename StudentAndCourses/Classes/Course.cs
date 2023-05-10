using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAndCourses.Classes
{
    internal class Course
    {
        public int id_courses { get; set; }
        public string CName { get; set; }
        public string CTeacher { get; set; }

        //public List<StudentCourse> Students { get; set; }
    }
}
