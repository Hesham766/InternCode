using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Management_System;

namespace School_Management_System
{
    public class Enrollment
    {
        public Student Student { get;  set; }
        public Course Course { get;  set; }
        public char Grade { get; set; } 
        public DateTime DateEnrolled { get; private set; }

        public Enrollment(Student student, Course course, char Grade)
        {
            Student = student;
            Course = course;
            DateEnrolled = DateTime.Now;
            this.Grade = Grade;
        }
    }
}