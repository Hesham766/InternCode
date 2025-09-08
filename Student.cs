using System;
using System.Linq;
using System.Text;

namespace School_Management_System
{
    public class Student
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; private set; }
        public List<Course> EnrolledCourses { get; private set; }

        public Student(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            EnrolledCourses = new List<Course>(); // A student starts with no courses.
        }
    }
}
