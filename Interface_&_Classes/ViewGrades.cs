using School_Management_System;

public class ViewGrades : IStudentServices
{
    public char Grade { get; set; }
    public string Execute(Student student, Course course)
    {
        if (Grade == '\0')
            return "No grades available\n";

        // Logic to view grades of the student for the course
        Console.WriteLine($"Viewing grades...");
        return $"Grade for {student.Name} in {course.Title}: {Grade}\n";
    }
}