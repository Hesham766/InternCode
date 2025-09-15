using School_Management_System;

public class AssignGrades : IStudentServices
{
    public char Grade { get; set; }

    // need to implement this from IGrades interface
    public string Assign_View(Student student, Course course, char grade)
    {
        // student.EnrolledCourses.Add(grade);

    
        Console.WriteLine($"Assigned grade {grade} to {student.Name} for course {course.Title}\n");
        return $"Assigned grade {grade} to {student.Name} for course {course.Title}\n";
    }


///////////////////////////////////////////////////////////////////////////////////////////////////
    public void Enroll_Drop(Student student, Course course)
    {
        throw new NotImplementedException();
    }

}