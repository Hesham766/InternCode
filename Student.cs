using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // Student.Enroll(Course) → enrolls a student
        // A student can enroll in a course.
        public void EnrollInCourse(Course course)
        {
            if (course != null && !EnrolledCourses.Contains(course))
            {
                EnrolledCourses.Add(course); // Add course to student's list
                course.AddStudent(this);     // Also tell the course to add this student
                Console.WriteLine($"Success: {Name} has been enrolled in {course.Title}.");
            }
            else
            {
                Console.WriteLine($"Error: Student {Name} is already enrolled in {course?.Title} or the course is invalid.");
            }
        }

        // A student can drop a course.
        public void DropCourse(Course course)
        {
            if (course != null && EnrolledCourses.Contains(course))
            {
                EnrolledCourses.Remove(course); // Remove course from student's list
                course.RemoveStudent(this);     // Also tell the course to remove this student
                Console.WriteLine($"Success: {Name} has dropped {course.Title}.");
            }
            else
            {
                Console.WriteLine($"Error: Student {Name} is not enrolled in {course?.Title}.");
            }
        }

        // Display all courses this student is enrolled in.
        public void DisplayEnrolledCourses()
        {
            Console.WriteLine($"--- Courses for {Name} (ID: {Id}) ---");
            if (EnrolledCourses.Count == 0)
            {
                Console.WriteLine("Not enrolled in any courses.");
            }
            else
            {
                foreach (var course in EnrolledCourses)
                {
                    Console.WriteLine($"- {course.Title} ({course.Code})");
                }
            }
            Console.WriteLine("------------------------------------");
        }
    }
}
