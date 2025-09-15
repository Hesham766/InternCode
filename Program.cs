namespace School_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {

            ConsoleLogs logs = new ConsoleLogs();
            List<Course> EnrolledCourses = new List<Course>();
            List<Student> EnrolledStudents = new List<Student>();
            var enrollments = new List<Enrollment>();
            var seed = new Seeds();
            var courses = seed.courses;
            var students = seed.students;

            IStudentServices enrollService = new EnrollInCourse();
            IStudentServices dropService = new DropCourse();
            IStudentServices assignGradeService = new AssignGrades();
            IStudentServices viewGradeService = new ViewGrades();


            bool flag = true;

            while (flag)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    logs.MainMenu();
                    switch (choice)
                    {
                        case 1:

                            logs.CoursesList();

                            Console.WriteLine("Enter Course Code to enroll: ");
                            var courseCode = Console.ReadLine();

                            Console.WriteLine("Enter Student ID to enroll: ");
                            var studentId = Console.ReadLine();

                            // enrollService.Enroll_Drop(studentId, courseCode);
                            // EnrolledCourses.Add(courses);
                            break;

                        case 2:
                            break;

                        case 3:
                            break;

                        case 4:
                            break;

                        case 9:
                            Console.Beep(1000, 500);
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