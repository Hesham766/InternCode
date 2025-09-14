using System;
using System.Text;
using System.Collections.Generic;

namespace School_Management_System
{
    public class Seeds
    {
        Course course1 = new Course(1, "MAT101", "Calculus I", 4);
        Course course2 = new Course(2, "PHY101", "Physics I", 2);
        Course course3 = new Course(3, "STA101", "Statistics & Probability", 2);
        Course course4 = new Course(4, "CSE101", "Introduction to Programming", 3);
        Course course5 = new Course(5, "DSA101", "Data Structures", 3);
        public List<Course> courses { get; set; }
        public List<Course> Courses { get; private set; }

        Student student1 = new Student(111, "Hesham", "hesham@example.com", "1111");
        Student student2 = new Student(222, "Eslam", "eslam@example.com", "2222");
        Student student3 = new Student(333, "Farag", "farag@example.com", "3333");
        Student student4 = new Student(444, "Fat7y", "fat7y@example.com", "4444");
        Student student5 = new Student(555, "Adel", "adel@example.com", "5555");
        public List<Student> students { get; set; }
        public List<Student> Students { get; private set; }

        public Seeds()
        {
            var courseList = new List<Course> { course1, course2, course3, course4, course5 };
            courses = courseList;
            Courses = courseList;

            var studentList = new List<Student> { student1, student2, student3, student4, student5 };
            students = studentList;
            Students = studentList;
        }
    }
}