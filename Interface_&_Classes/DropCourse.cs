using School_Management_System;

public class DropCourse : IStudentServices
{
    public string Execute(Student student, Course course)
    {
        if (!student.EnrolledCourses.Contains(course))
            return $"{student.Name} is not enrolled in {course.Title}\n";
        
        student.EnrolledCourses.Remove(course);
        course.EnrolledStudents.Remove(student);
        return $"{student.Name} has dropped {course.Title}\n";
    }
}