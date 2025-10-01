using School_Management_System;

public class AssignGrades : IStudentServices
{
    public char Grade { get; set; }
    public string Execute(Student student, Course course)
    {
        if (student == null || course == null)
        {
            return "Student or Course cannot be null.";
        }

        if (!student.EnrolledCourses.Contains(course))
        {
            return $"{student.Name} is not enrolled in {course.Title}.\n";
        }
        var input = Console.ReadLine();

        Grade = char.ToUpperInvariant(input.Trim()[0]);

        return $"Assigned grade {Grade} to {student.Name} for course {course.Title}.\n";
    }

}