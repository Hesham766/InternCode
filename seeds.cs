using System;
using System.Text;

public class seeds
{
    
    List<Course> courses = new List<Course> { course1, course2, course3, course4, course5 };

    Course course1 = new Course(1, "MAT101", "Calculus I", 4);
    Course course2 = new Course(2, "PHY101", "Physics I", 2);
    Course course3 = new Course(3, "STA101", "Statistics & Probability", 2);
    Course course4 = new Course(4, "CSE101", "Introduction to Programming", 3);
    Course course5 = new Course(5, "DSA101", "Data Structures", 3);

    
    List<Student> students = new List<Student> { student1, student2, student3 };

    Student student1 = new Student(000, "Hesham", "hesham@example.com", "0000");
    Student student2 = new Student(111, "Eslam", "eslam@example.com", "1111");
    Student student4 = new Student(222, "Farag", "farag@example.com", "2222");
    Student student5 = new Student(333, "Fat7y", "fat7y@example.com", "3333");
    Student student6 = new Student(444, "Adel", "adel@example.com", "4444");

    
}