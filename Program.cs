using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Course course1 = new Course(1, "MAT101", "Calculus I", 4);
            Course course2 = new Course(2, "PHY101", "Physics I", 2);
            Course course3 = new Course(3, "STA101", "Statistics & Probability", 2);
            Course course4 = new Course(4, "CSE101", "Introduction to Programming", 3);
            Course course5 = new Course(5, "DSA101", "Data Structures", 3);
            List<Course> courses = new List<Course> { course1, course2, course3, course4, course5 };

            Student student1 = new Student(123, "Hesham", "hesham@example.com", "password123");
            Student student2 = new Student(456, "Eslam", "eslam@example.com", "password456");
            Student student3 = new Student(789, "Hamza", "hamza@example.com", "password789");
            List<Student> students = new List<Student> { student1, student2, student3 };

            List<Course> EnrolledCourses = new List<Course>();


            bool flag = true;

            while (flag)
            {
                Console.WriteLine("\n");
                Console.WriteLine("===  ============================ ===");
                Console.WriteLine("===    School_Management_System   ===");
                Console.WriteLine("===  ============================ ===");
                Console.WriteLine("===  (1) to Enroll Course         ===");
                Console.WriteLine("===  (2) to Drop Course           ===");
                Console.WriteLine("===  (3) to View Enrolled Courses ===");
                Console.WriteLine("===  (4) to Assign Grade          ===");
                Console.WriteLine("===  (5) to View Grades           ===");
                Console.WriteLine("===  (9) to Exit                  ===");
                Console.WriteLine("===  ============================ ===");
                Console.Write("\nEnter Your Choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("============ Enroll Courses ==========");
                            Console.WriteLine("Name: Calculus I -------- Code: MAT101");
                            Console.WriteLine("Name: Physics I  -------- Code: PHY101");
                            Console.WriteLine("Name: Stats&Prob -------- Code: STA101");
                            Console.WriteLine("Name: Intro_to_Prog ----- Code: CSE101");
                            Console.WriteLine("Name: Data Structures --- Code: DSA101");
                            Console.WriteLine("======================================");


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