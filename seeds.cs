using System.Collections.Generic;

namespace School_Management_System
{
    public class Seeds
    {
        public List<Course> Courses { get; } = new()
        {
            new Course(1, "MAT101", "Calculus I", 4),
            new Course(2, "PHY101", "Physics I", 2),
            new Course(3, "STA101", "Statistics & Probability", 2),
            new Course(4, "CSE101", "Introduction to Programming", 3),
            new Course(5, "DSA101", "Data Structures", 3)
        };

        public List<Student> Students { get; } = new()
        {
            new Student(111, "Hesham", "hesham@example.com", "1111"),
            new Student(222, "Eslam", "eslam@example.com", "2222"),
            new Student(333, "Farag", "farag@example.com", "3333"),
            new Student(444, "Fat7y", "fat7y@example.com", "4444"),
            new Student(555, "Adel", "adel@example.com", "5555")
        };
    }
}