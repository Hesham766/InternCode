using System;

public class Methods
{
    #region Student Methods


        // Student.Enroll(Course) → enrolls a student
        // A student can enroll in a course.
        public void EnrollInCourse(Course course)
        {
            if (course != null && !EnrolledCourses.Contains(course))
            {
                EnrolledCourses.Add(course); // Add course to student's list
                course.AddStudent(this);     // Also tell the course to add this student
                Console.WriteLine($"Success: {Name} has been enrolled in {course.Title}.");
            }
            else
            {
                Console.WriteLine($"Error: Student {Name} is already enrolled in {course?.Title} or the course is invalid.");
            }
        }

        // A student can drop a course.
        public void DropCourse(Course course)
        {
            if (course != null && EnrolledCourses.Contains(course))
            {
                EnrolledCourses.Remove(course); // Remove course from student's list
                course.RemoveStudent(this);     // Also tell the course to remove this student
                Console.WriteLine($"Success: {Name} has dropped {course.Title}.");
            }
            else
            {
                Console.WriteLine($"Error: Student {Name} is not enrolled in {course?.Title}.");
            }
        }

        // Display all courses this student is enrolled in.
        public void DisplayEnrolledCourses()
        {
            Console.WriteLine($"--- Courses for {Name} (ID: {Id}) ---");
            if (EnrolledCourses.Count == 0)
            {
                Console.WriteLine("Not enrolled in any courses.");
            }
            else
            {
                foreach (var course in EnrolledCourses)
                {
                    Console.WriteLine($"- {course.Title} - ({course.Code})");
                }
            }
            Console.WriteLine("------------------------------------");
        }

    #endregion

    #region Course Methods


        public void AddStudent(Student student)
        {
            if (!EnrolledStudents.Contains(student))
            {
                EnrolledStudents.Add(student);
            }
        }

        public void RemoveStudent(Student student)
        {
            if (EnrolledStudents.Contains(student))
            {
                EnrolledStudents.Remove(student);
            }
        }


    #endregion

    #region Enrollment Methods


        public void AssignGrade(char grade)
        {

            char upperGrade = char.ToUpper(grade);
            // Simplified grade validation
            if (upperGrade == 'A' || upperGrade == 'B' || upperGrade == 'C' || upperGrade == 'D' || upperGrade == 'F')
            {
                Console.WriteLine($"Grade '{Grade}' assigned to {Student.Name} for course {Course.Title}.");
            }
            else
            {
                Console.WriteLine("Error: Invalid grade. Please use A, B, C, D, or F.");
            }
        }

        // Enrollment.ViewGrade() → views the assigned grade
        public void ViewGrade(Student student, Course course)
        {
            if (Grade != null)
            {
                Console.WriteLine($"Student: {student.Name}\nCourse: {course.Title}\nAssigned Grade: {Grade}\n");
            }
            else
                Console.WriteLine("No grade assigned yet.");

            }
            

    #endregion
}