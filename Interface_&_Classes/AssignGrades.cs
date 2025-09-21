using School_Management_System;

public class AssignGrades : IStudentServices
{
    public char Grade { get; set; }

    // need to implement this from IGrades interface
    public string Execute(Student student, Course course)
    {
        // student.EnrolledCourses.Add(grade);

        Console.WriteLine($"Assigned grade {Grade} to {student.Name} for course {course.Title}\n");
        return $"Assigned grade {Grade} to {student.Name} for course {course.Title}\n";
    }
}