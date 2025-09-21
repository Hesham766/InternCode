using School_Management_System;

public class EnrollInCourse : IStudentServices
{

    public string Execute(Student student, Course course)
    {
        if (student.EnrolledCourses.Contains(course))
        {
            return $"{student.Name} is already enrolled in {course.Title}\n";
        }

        student.EnrolledCourses.Add(course);
        course.EnrolledStudents.Add(student);
        return $"{student.Name} has been enrolled in {course.Title}\n";
    }
    public void DisplayEnrolledCourses(Student student, Course course)
    {
        foreach (var items in student.EnrolledCourses)
            Console.WriteLine($"Enrolled Courses: {items.Title}\n");
    }
}