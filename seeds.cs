using System;
using System.Text;
using System.Collections.Generic;

namespace School_Management_System
{
    public static class Seeds
    {
        static Seeds()
        {
            courses = new List<Course> { course1, course2, course3, course4, course5 };
            students = new List<Student> { student1, student2, student3, student4, student5 };
        }

        static Course course1 = new Course(1, "MAT101", "Calculus I", 4);
        static Course course2 = new Course(2, "PHY101", "Physics I", 2);
        static Course course3 = new Course(3, "STA101", "Statistics & Probability", 2);
        static Course course4 = new Course(4, "CSE101", "Introduction to Programming", 3);
        static Course course5 = new Course(5, "DSA101", "Data Structures", 3);
        public static List<Course> courses { get; set; }

        static Student student1 = new Student(111, "Hesham", "hesham@example.com", "password1");
        static Student student2 = new Student(222, "Eslam", "eslam@example.com", "password2");
        static Student student3 = new Student(333, "Farag", "farag@example.com", "password3");
        static Student student4 = new Student(444, "Fat7y", "fat7y@example.com", "password4");
        static Student student5 = new Student(555, "Adel", "adel@example.com", "password5");
        public static List<Student> students { get; set; }
    }
}