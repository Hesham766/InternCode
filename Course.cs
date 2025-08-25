using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System
{
    public class Course
    {
        public int Id { get; set; }
        private string code = string.Empty;
        public string Code
        {
            get { return code; }
            set
            {
                // A course code must follow the format ABC123
                while (true)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(value, @"^[A-Z]{3}\d{3}$"))
                    {
                        code = value;
                        break;
                    }
                    Console.WriteLine("Invalid code format. The correct format is: ABC123");
                    value = Console.ReadLine() ?? string.Empty;
                }
            }
        }

        public string Title { get; set; }
        public int Credits { get; set; }

        public List<Student> EnrolledStudents { get; set; } = new List<Student>();
        public List<Course> EnrolledCourses { get; set; } = new List<Course>();

        public Enrollment Enrollments { get; set; } 
        public Course(int id, string code, string title, int credits)
        {
            Id = id;
            Code = code;
            Title = title;
            Credits = credits;
        }
        public void AddStudent(Student student)
        {
            if (!EnrolledStudents.Contains(student))
            {
                EnrolledStudents.Add(student);
            }
        }

        public void RemoveStudent(Student student)
        {
            if (EnrolledStudents.Contains(student))
            {
                EnrolledStudents.Remove(student);
            }
        }
    }
}