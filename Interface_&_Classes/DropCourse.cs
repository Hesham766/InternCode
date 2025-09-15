using School_Management_System;

public class DropCourse : IStudentServices
{
    public void Enroll_Drop(Student student, Course course)
    {
        if (!student.EnrolledCourses.Contains(course))
        {
            Console.WriteLine($"{student.Name} is not enrolled in {course.Title}\n");
            return;
        }

        student.EnrolledCourses.Remove(course);
        course.EnrolledStudents.Remove(student);
        Console.WriteLine($"{student.Name} has dropped {course.Title}\n");
    }

///////////////////////////////////////////////////////////////////////////////////////////////////

    public string Assign_View(Student student, Course course, char grade)
    {
        throw new NotImplementedException();
    }
}