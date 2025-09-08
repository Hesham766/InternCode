using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace School_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Course> EnrolledCourses = new List<Course>();


            bool flag = true;

            while (flag)
            {
                ConsoleLogs.MainMenu();

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ConsoleLogs.CoursesList();

                            #region Using AI Co-Pilot
                            Console.WriteLine("\nEnter Course Code to enroll: ");
                            var inputCode = Console.ReadLine()?.Trim();
                            var selectedCourse = courses.FirstOrDefault(course => string.Equals(course.Code, inputCode));

                            Console.WriteLine("\nEnter Student ID to enroll: ");
                            var inputId = Console.ReadLine()?.Trim();
                            var student = students.FirstOrDefault(student => student.Id == int.Parse(inputId));
                            #endregion


                            if (selectedCourse != null && int.TryParse(inputId, out int studentId))
                            {
                                if (student != null)
                                {
                                    student.EnrollInCourse(selectedCourse);
                                    EnrolledCourses.Add(selectedCourse);
                                }
                                else
                                {
                                    Console.WriteLine("Student not found. Please check the student ID and try again.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Course not found. Please check the course code and try again.");
                            }
                            break;

                        case 2:
                            Console.WriteLine("=== Drop Course ===");
                            Console.WriteLine("Enter Course Code to drop: ");
                            Console.ReadLine();

                            break;

                        case 3:
                            Console.WriteLine("=== View Enrolled Courses ===");
                            foreach (var enrolledCourse in EnrolledCourses)
                            {
                                Console.WriteLine($"Course Name: {enrolledCourse.Title}, Course Code: {enrolledCourse.Code}");
                            }
                            break;

                        case 4:
                            Console.WriteLine("=== Assign Grade ===");
                            ConsoleLogs.GradesList();

                            foreach (var i in students)
                            {
                                foreach (var j in i.EnrolledCourses)
                                {
                                    Console.WriteLine($"Enter grade for {i.Name} in {j.Title}: ");
                                    var gradeInput = char.Parse(Console.ReadLine());
                                    var Enrollment = new Enrollment(i, j,gradeInput);
                                    Enrollment.AssignGrade(gradeInput);
                                }
                            }
                            break;

                        case 5: // need to be fixed
                            Console.WriteLine("=== View Grades ===");
                            Console.WriteLine("Enter StudentID: ");
                            var studentIdInput = int.Parse(Console.ReadLine());

                            foreach (var i in students)
                            { 
                                if(i.Id==studentIdInput)
                                {
                                    foreach (var j in i.EnrolledCourses)
                                    {
                                        var Enrollment = new Enrollment(i, j,j.Enrollments.Grade);
                                        Enrollment.ViewGrade(i, j);
                                    }
                                }
                            }
                            
                            break;

                        case 9:
                            Console.WriteLine("=== Console Closed ===");
                            flag = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number: ");
                }
            }
        }
    }
}