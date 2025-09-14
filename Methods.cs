using System;
using School_Management_System;

public static class Methods
{
    #region Student Methods

    // Student.Enroll(Course) → enrolls a student
    // A student can enroll in a course. (static helper)
    public static void EnrollInCourse(Student student, Course course)
    {
        if (course != null && !student.EnrolledCourses.Contains(course))
        {
            student.EnrolledCourses.Add(course); // Add course to student's list
            AddStudent(course, student);          // Also tell the course helper to add this student
            Console.WriteLine($"Success: {student.Name} has been enrolled in {course.Title}.");
        }
        else
        {
            Console.WriteLine($"Error: Student {student.Name} is already enrolled in {course?.Title} or the course is invalid.");
        }
    }

    // A student can drop a course.
    public static void DropCourse(Student student, Course course)
    {
        if (course != null && student.EnrolledCourses.Contains(course))
        {
            student.EnrolledCourses.Remove(course); // Remove course from student's list
            RemoveStudent(course, student);          // Also tell the course helper to remove this student
            Console.WriteLine($"Success: {student.Name} has dropped {course.Title}.");
        }
        else
        {
            Console.WriteLine($"Error: Student {student.Name} is not enrolled in {course?.Title}.");
        }
    }

    // Display all courses this student is enrolled in.
    public static void DisplayEnrolledCourses(Student student)
    {
        Console.WriteLine($"--- Courses for {student.Name} (ID: {student.Id}) ---");
        if (student.EnrolledCourses.Count == 0)
        {
            Console.WriteLine("Not enrolled in any courses.");
        }
        else
        {
            foreach (var course in student.EnrolledCourses)
            {
                Console.WriteLine($"- {course.Title} - ({course.Code})");
            }
        }
        Console.WriteLine("------------------------------------");
    }

    #endregion

    #region Course Methods

    public static void AddStudent(Course course, Student student)
    {
        if (course == null || student == null) return;
        if (!course.EnrolledStudents.Contains(student))
        {
            course.EnrolledStudents.Add(student);
        }
    }

    public static void RemoveStudent(Course course, Student student)
    {
        if (course == null || student == null) return;
        if (course.EnrolledStudents.Contains(student))
        {
            course.EnrolledStudents.Remove(student);
        }
    }

    #endregion

    #region Enrollment Methods

    public static void AssignGrade(Enrollment enrollment, char grade)
    {
        if (enrollment == null)
        {
            Console.WriteLine("No Enrollments found");
            return;
        }

        char upperGrade = char.ToUpper(grade);
        // Simplified grade validation
        if (upperGrade == 'A' || upperGrade == 'B' || upperGrade == 'C' || upperGrade == 'D' || upperGrade == 'F')
        {
            enrollment.Grade = upperGrade;
            Console.WriteLine($"Grade '{enrollment.Grade}' assigned to {enrollment.Student.Name} for course {enrollment.Course.Title}.");
        }
        else
        {
            Console.WriteLine("Error: Invalid grade. Please use A, B, C, D, or F.");
        }
    }
    
    // Enrollment.ViewGrade() → views the assigned grade
    public static void ViewGrade(Enrollment enrollment)
    {
        if (enrollment == null)
        {
            Console.WriteLine("No Enrollments found");
            return;
        }

        if (enrollment.Grade != '\0')
        {
            Console.WriteLine($"Student: {enrollment.Student.Name}\nCourse: {enrollment.Course.Title}\nAssigned Grade: {enrollment.Grade}\n");
        }
        else
        {
            Console.WriteLine("No grade assigned yet.");
        }

    }


    #endregion
}