using System.Runtime.CompilerServices;

namespace School_Management_System
{
    class Program
    {
        public void DisplayEnrolledCourses(Student student, Course course)
        {
            foreach (var items in student.EnrolledCourses)
                Console.WriteLine($"Enrolled Courses: {items.Title}\n");
        }
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
                        case 1:
                            // Enroll in course
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
                            }
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine($"{selectedStudent.Name} has been enrolled in {selectedCourse.Title}.");
                            break;

                        case 2:
                            // Drop Course

                            Console.WriteLine("\nEnter Student ID to drop: ");
                            uint parsedInputId2;
                            flag = true;
                            do
                                flag = uint.TryParse(Console.ReadLine()?.Trim(), out parsedInputId2);
                            while (!flag);
                            var selectedStudent2 = students.FirstOrDefault(student => student.Id == parsedInputId2);
                           

                            Console.WriteLine($"Courses Enrolled for {selectedStudent2.Name}:");
                            // foreach (var course in selectedEnrolledCourses)
                            // {
                            //     Console.WriteLine($"- {course.Course.Title}");
                            // }

                            Console.WriteLine("\nEnter Course Code to drop: ");
                            var inputCode2 = Console.ReadLine()?.Trim();
                            var selectedCourse2 = courses.FirstOrDefault(course => string.Equals(course.Code, inputCode2, StringComparison.OrdinalIgnoreCase));

                            if (selectedCourse2 != null && selectedStudent2 != null)
                            {
                                context.SetStrategy(new DropCourse());
                                context.ExecuteStrategy(selectedStudent2, selectedCourse2);
                                enrollments.Remove(new Enrollment(selectedStudent2, selectedCourse2, '\0', DateTime.Now));
                            }
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine($"{selectedStudent2.Name} has been dropped from {selectedCourse2.Title}.");
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
                            Console.Beep(1000, 500);
                            Console.WriteLine("Thank you for using the School Management System. Goodbye!");
                            flag = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            /*
            List<Course> EnrolledCourses = new List<Course>();
            ConsoleLogs Logs = new ConsoleLogs();
            var seed = new Seeds();
            var courses = seed.courses;
            var students = seed.students;
                }
                
            }

            /*
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

                            #region Using AI Co-Pilot

                            Console.WriteLine("\nEnter Course Code to enroll: ");
                            var inputCode = Console.ReadLine()?.Trim();
                            var selectedCourse = courses.FirstOrDefault(course => string.Equals(course.Code, inputCode, StringComparison.OrdinalIgnoreCase));

                            Console.WriteLine("\nEnter Student ID to enroll: ");
                            var inputId = Console.ReadLine()?.Trim();
                            int.TryParse(inputId, out var parsedInputId);
                            var student = students.FirstOrDefault(student => student.Id == parsedInputId);
                            #endregion


                            if (selectedCourse != null && int.TryParse(inputId, out int studentId))
                            {
                                if (student != null)
                                {
                                    Console.Clear();
                                    Methods.EnrollInCourse(student, selectedCourse);
                                    EnrolledCourses.Add(selectedCourse);
                                    enrollments.Add(new Enrollment(student, selectedCourse, '\0'));

                                }
                                else
                                {
                                    Console.WriteLine("Student not found. Please check the student ID and try again.");
                                    Console.Clear();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Course not found. Please check the course code and try again.");

                                Console.Clear();
                            }
                            break;


                        case 2:
                            Console.WriteLine("=== Drop Course ===");

                            #region Using AI

                            Console.WriteLine("Enter Course Code to drop: ");
                            var dropCode = Console.ReadLine()?.Trim();
                            var dropCourse = courses.FirstOrDefault(course => string.Equals(course.Code, dropCode));

                            Console.WriteLine("Enter Student ID to drop: ");
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
                                    Console.WriteLine("Student not found. Please check the student ID and try again.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Course not found. Please check the course code and try again.");
                            }
                            break;
                        #endregion

                        case 3:
                            Console.WriteLine("=== View Enrolled Courses ===");
                            foreach (var enrolledCourse in EnrolledCourses)
                            {
                                Console.WriteLine($"Course Name: {enrolledCourse.Title}, Course Code: {enrolledCourse.Code}");
                            }
                            break;

                        case 4:
                            Console.WriteLine("=== Assign Grade ===");
                            Logs.GradesList();

                            foreach (var enrollment in enrollments)
                            {
                                Console.WriteLine($"Enter grade for {enrollment.Student.Name} in {enrollment.Course.Title}: ");
                                var gradeStr = Console.ReadLine() ?? string.Empty;
                                if (!string.IsNullOrEmpty(gradeStr) && char.TryParse(gradeStr.Trim(), out var gradeInput))
                                {
                                    Methods.AssignGrade(enrollment, gradeInput);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid grade input. Skipping.");
                                }
                            }
                            break;

                        case 5: // need to be fixed
                            Console.WriteLine("=== View Grades ===");
                            Console.WriteLine("Enter StudentID: ");
                            var studentIdInputStr = Console.ReadLine() ?? string.Empty;
                            int.TryParse(studentIdInputStr, out var studentIdInput);
                            var studentEnrollments = enrollments.Where(e => e.Student.Id == studentIdInput);
                            foreach (var e in studentEnrollments)
                            {
                                Methods.ViewGrade(e);
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
            */
        }
    }
}