using System.Runtime.CompilerServices;

namespace School_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            // IStudentServices enrollService = new EnrollInCourse();
            // IStudentServices dropService = new DropCourse();
            // IStudentServices assignGradeService = new AssignGrades();
            // IStudentServices viewGradeService = new ViewGrades();

            var context = new StudentContext(new EnrollInCourse());


            var courses = Seeds.courses;
            var students = Seeds.students;
            var enrollments = new List<Enrollment>();

            bool flag = true;
            int choice;

            while (flag)
            {
                ConsoleLogs.MainMenu();
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1: // Enroll in course

                            ConsoleLogs.CoursesList();

                            Console.WriteLine("\nEnter Course Code to enroll: ");
                            var inputCode = Console.ReadLine()?.Trim();
                            var selectedCourse = courses.FirstOrDefault(course => string.Equals(course.Code, inputCode, StringComparison.OrdinalIgnoreCase));

                            Console.WriteLine("\nEnter Student ID to enroll: ");
                            uint parsedInputId;
                            flag = true;
                            do
                                flag = uint.TryParse(Console.ReadLine()?.Trim(), out parsedInputId);
                            while (!flag);
                            var selectedStudent = students.FirstOrDefault(student => student.Id == parsedInputId);

                            if (selectedCourse != null && selectedStudent != null)
                            {
                                context.ExecuteStrategy(selectedStudent, selectedCourse);
                                enrollments.Add(new Enrollment(selectedStudent, selectedCourse, '\0', DateTime.Now));
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine($"{selectedStudent.Name} has been enrolled in {selectedCourse.Title}.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid student ID or course code. Please try again.");
                            }
                            break;



                        case 2: // Drop Course


                            Console.WriteLine("\nEnter Student ID to drop: ");
                            uint parsedInputId2;
                            flag = true;
                            do
                                flag = uint.TryParse(Console.ReadLine()?.Trim(), out parsedInputId2);
                            while (!flag);
                            var selectedStudent2 = students.FirstOrDefault(student => student.Id == parsedInputId2);

                            if (selectedStudent2 != null)
                            {
                                Console.WriteLine($"Courses Enrolled for {selectedStudent2.Name}:");
                                // foreach (var course in selectedEnrolledCourses)
                                // {
                                //     Console.WriteLine($"- {course.Course.Title}");
                                // }

                                Console.WriteLine("\nEnter Course Code to drop: ");
                                var inputCode2 = Console.ReadLine()?.Trim();
                                var selectedCourse2 = courses.FirstOrDefault(course => string.Equals(course.Code, inputCode2, StringComparison.OrdinalIgnoreCase));

                                if (selectedCourse2 != null)
                                {
                                    context.SetStrategy(new DropCourse());
                                    context.ExecuteStrategy(selectedStudent2, selectedCourse2);
                                    enrollments.Remove(new Enrollment(selectedStudent2, selectedCourse2, '\0', DateTime.Now));
                                    Console.Clear();
                                    Console.WriteLine();
                                    Console.WriteLine($"{selectedStudent2.Name} has been dropped from {selectedCourse2.Title}.");
                                }
                                else
                                {
                                    Console.WriteLine("Course not found. Please check the course code and try again.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Student not found. Please check the student ID and try again.");
                            }
                            break;


                        case 3:
                            // view enrolled courses

                            break;

                        case 4:
                            // assign grade
                            
                            break;

                        case 5:
                            // view grades

                            break;

                        case 9:
                            Console.Clear();
                            Console.WriteLine("Thank you for using the School Management System. Goodbye!");
                            flag = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }

        public void DisplayEnrolledCourses(Student student, Course course)
        {
            foreach (var items in student.EnrolledCourses)
                Console.WriteLine($"Enrolled Courses: {items.Title}\n");
        }
    }
}