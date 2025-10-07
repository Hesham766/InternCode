using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Collections.Generic;
using School_Management_System;


namespace School_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Course> EnrolledCourses = new List<Course>();
            ConsoleLogs Logs = new ConsoleLogs();
            var seed = new Seeds();
            var courses = seed.courses;
            var students = seed.students;
            var enrollments = new List<Enrollment>();

            bool flag = true;

            while (flag)
            {
                Logs.MainMenu();

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Logs.CoursesList();

                            Logger.Info("\nEnter Course Code to enroll: ");
                            var inputCode = Console.ReadLine()?.Trim();
                            var selectedCourse = courses.FirstOrDefault(course => string.Equals(course.Code, inputCode, StringComparison.OrdinalIgnoreCase));

                            Logger.Info("\nEnter Student ID to enroll: ");
                            var inputId = Console.ReadLine()?.Trim();
                            int.TryParse(inputId, out var parsedInputId);
                            var student = students.FirstOrDefault(student => student.Id == parsedInputId);

                            if (selectedCourse != null && int.TryParse(inputId, out int studentId))
                            {
                                if (student != null)
                                {
                                    Methods.EnrollInCourse(student, selectedCourse);
                                    EnrolledCourses.Add(selectedCourse);
                                    enrollments.Add(new Enrollment(student, selectedCourse, '\0'));
                                }
                                else
                                {
                                    Logger.Error("Student not found. Please check the student ID and try again.");
                                }
                            }
                            else
                            {
                                Logger.Error("Course not found. Please check the course code and try again.");
                            }
                            break;

                        case 2:
                            Logger.Info("=== Drop Course ===");

                            Logger.Info("Enter Course Code to drop: ");
                            var dropCode = Console.ReadLine()?.Trim();
                            var dropCourse = courses.FirstOrDefault(course => string.Equals(course.Code, dropCode));

                            Logger.Info("Enter Student ID to drop: ");
                            var dropId = Console.ReadLine()?.Trim();
                            int.TryParse(dropId, out var parsedDropId);
                            var dropStudent = students.FirstOrDefault(student => student.Id == parsedDropId);

                            if (dropCourse != null && int.TryParse(dropId, out int dropStudentId))
                            {
                                if (dropStudent != null)
                                {
                                    Methods.DropCourse(dropStudent, dropCourse);
                                    EnrolledCourses.Remove(dropCourse);
                                }
                                else
                                {
                                    Logger.Error("Student not found. Please check the student ID and try again.");
                                }
                            }
                            else
                            {
                                Logger.Error("Course not found. Please check the course code and try again.");
                            }
                            break;

                        case 3:
                            Logger.Info("=== View Enrolled Courses ===");
                            foreach (var enrolledCourse in EnrolledCourses)
                            {
                                Logger.Info($"Course Name: {enrolledCourse.Title}, Course Code: {enrolledCourse.Code}");
                            }
                            break;

                        case 4:
                            Logger.Info("=== Assign Grade ===");
                            Logs.GradesList();

                            foreach (var enrollment in enrollments)
                            {
                                Logger.Info($"Enter grade for {enrollment.Student.Name} in {enrollment.Course.Title}: ");
                                var gradeStr = Console.ReadLine() ?? string.Empty;
                                if (!string.IsNullOrEmpty(gradeStr) && char.TryParse(gradeStr.Trim(), out var gradeInput))
                                {
                                    Methods.AssignGrade(enrollment, gradeInput);
                                }
                                else
                                {
                                    Logger.Warning("Invalid grade input. Skipping.");
                                }
                            }
                            break;

                        case 5: // need to be fixed
                            Logger.Info("=== View Grades ===");
                            Logger.Info("Enter StudentID: ");
                            var studentIdInputStr = Console.ReadLine() ?? string.Empty;
                            int.TryParse(studentIdInputStr, out var studentIdInput);
                            var studentEnrollments = enrollments.Where(e => e.Student.Id == studentIdInput);
                            foreach (var e in studentEnrollments)
                            {
                                Methods.ViewGrade(e);
                            }

                            break;

                        case 9:
                            Logger.Info("=== Console Closed ===");
                            flag = false;
                            break;

                        default:
                            Logger.Warning("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Logger.Warning("Invalid input. Please enter a valid number: ");
                }
            }
        }
    }
}