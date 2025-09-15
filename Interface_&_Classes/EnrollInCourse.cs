using School_Management_System;

public class EnrollInCourse : IStudentServices
{

    public void Enroll_Drop(Student student, Course course)
    {
        if (student.EnrolledCourses.Contains(course))
        {
            Console.WriteLine($"{student.Name} is already enrolled in {course.Title}\n");
            return;
        }

        student.EnrolledCourses.Add(course);
        course.EnrolledStudents.Add(student);
        Console.WriteLine($"{student.Name} has been enrolled in {course.Title}\n");
    }
    public void DisplayEnrolledCourses(Student student, Course course)
    {
        foreach (var items in student.EnrolledCourses)
            Console.WriteLine($"Enrolled Courses: {items.Title}\n");
    }

///////////////////////////////////////////////////////////////////////////////////////////////////
    public string Assign_View(Student student, Course course, char grade)
    {
        throw new NotImplementedException();
    }
}