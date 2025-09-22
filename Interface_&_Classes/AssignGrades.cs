using School_Management_System;

public class AssignGrades : IStudentServices
{
    public char Grade { get; set; }

    // need to implement this from IStudentServices interface
    public string Execute(Student student, Course course)
    {


        return $"Assigned grade {Grade} to {student.Name} for course {course.Title}\n";
    }
}