using School_Management_System;

public class ViewGrades : IStudentServices
{
    public string Assign_View(Student student, Course course, char grade)
    {
        if (grade == '\0') return "No grades available\n";

        // Logic to view grades of the student for the course
        Console.WriteLine($"Viewing grades...");
        return $"Grade for {student.Name} in {course.Title}: {grade}\n";
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////
    public void Enroll_Drop(Student student, Course course)
    {
        throw new NotImplementedException();
    }
}