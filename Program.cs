namespace School_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            var seeds = new Seeds();
            var courses = seeds.Courses;
            var students = seeds.Students;
            var enrollments = new List<Enrollment>();

            var isRunning = true;

            while (isRunning)
            {
                AppMenus.MainMenu();
                int NumberChoice = int.TryParse(Console.ReadLine(), out var result) ? result : 0;

                switch (NumberChoice)
                {
                    case 1: // Enroll in course
                        Console.WriteLine();
                        AppMenus.CoursesList();
                        var inputCode = Methods.ReadCourseCode("Enter Course Code to enroll:");
                        var inputStudentId = Methods.ReadStudentId("Enter Student ID to enroll:");

                        var selectedCourse = courses.FirstOrDefault(course =>
                            string.Equals(course.Code, inputCode, StringComparison.OrdinalIgnoreCase));
                        var selectedStudent = students.FirstOrDefault(student => student.Id == (int)inputStudentId);

                        if (selectedCourse != null && selectedStudent != null)
                        {
                            Methods.EnrollInCourse(selectedStudent, selectedCourse);

                            if (!enrollments.Any(e => e.Student == selectedStudent && e.Course == selectedCourse))
                                enrollments.Add(new Enrollment(selectedStudent, selectedCourse, '\0'));

                            Console.Clear();
                            Console.WriteLine();
                            Logger.Success($"{selectedStudent.Name} has been enrolled in {selectedCourse.Title}.");
                        }
                        else
                            Logger.Error("Invalid student ID or course code. Please try again.");
                        break;

                    case 2: // Drop course

                        Console.WriteLine();

                        var droppedStudent = Methods.ReadStudentId("Enter Student ID: ");
                        var selectedStudent2 = students.FirstOrDefault(student => student.Id == (int)droppedStudent);

                        if (selectedStudent2 is not null)
                        {
                            if (selectedStudent2.EnrolledCourses.Any())
                            {
                                Logger.Info($"Courses enrolled for {selectedStudent2.Name}:");
                                Console.WriteLine();
                                foreach (var course in selectedStudent2.EnrolledCourses)
                                {
                                    Logger.Info($"- {course.Code} : {course.Title}");
                                }
                            }
                            else
                                Logger.Warning($"{selectedStudent2.Name} is not enrolled in any courses.");


                            var droppedCourse = Methods.ReadCourseCode("Enter Course Code to drop it: ");
                            var selectedCourse2 = courses.FirstOrDefault(course =>
                                string.Equals(course.Code, droppedCourse, StringComparison.OrdinalIgnoreCase));

                            if (selectedCourse2 is not null)
                            {
                                Methods.DropCourse(selectedStudent2, selectedCourse2);
                                var enrollmentToRemove = enrollments.FirstOrDefault(e => e.Student == selectedStudent2 && e.Course == selectedCourse2);

                                if (enrollmentToRemove is not null)
                                    enrollments.Remove(enrollmentToRemove);

                                Console.Clear();
                                Console.WriteLine();
                                Logger.Success($"{selectedStudent2.Name} has been dropped from {selectedCourse2.Title}.");
                            }
                            else
                                Logger.Error("Course not found. Please check the course code and try again.");

                        }
                        else
                            Logger.Error("Student not found. Please check the student ID and try again.");

                        break;

                    case 3: // View enrolled courses

                        Console.WriteLine();
                        var inputID = Methods.ReadStudentId("Enter Student ID to view enrolled courses:");
                        var selectedStudent3 = students.FirstOrDefault(student => student.Id == (int)inputID);

                        if (selectedStudent3 is not null)
                            Methods.DisplayEnrolledCourses(selectedStudent3);
                        else
                            Logger.Error("Student not found. check the student ID and try again.");
                        break;

                    case 4: // Assign grade

                        Console.WriteLine();
                        if (!enrollments.Any())
                        {
                            Logger.Warning("No enrollments available. Enroll students before assigning grades.");
                            break;
                        }

                        var studentIdToGrade = Methods.ReadStudentId("Enter Student ID to assign a grade:");
                        var selectedStudent4 = students.FirstOrDefault(student => student.Id == (int)studentIdToGrade);

                        if (selectedStudent4 is null)
                        {
                            Logger.Error("Student not found. check the student ID and try again.");
                            break;
                        }

                        var studentEnrollments = enrollments.Where(e => e.Student == selectedStudent4).ToList();

                        if (!studentEnrollments.Any())
                        {
                            Logger.Warning($"{selectedStudent4.Name} is not enrolled in any courses.");
                            break;
                        }

                        Logger.Info($"Select a course code to assign a grade for {selectedStudent4.Name}:");
                        foreach (var enrollment in studentEnrollments)
                        {
                            Logger.Info($"- {enrollment.Course.Code} : {enrollment.Course.Title}");
                        }

                        AppMenus.CoursesList();
                        var ReadedCode = Methods.ReadCourseCode("Enter Course Code: ");
                        var enrollmentToGrade = studentEnrollments.FirstOrDefault(e =>
                            string.Equals(e.Course.Code, ReadedCode, StringComparison.OrdinalIgnoreCase));

                        if (enrollmentToGrade == null)
                        {
                            Logger.Error("Course not found in the student's enrollments.");
                            break;
                        }

                        AppMenus.GradesList();
                        var inputGrade = Methods.ReadGrade("Enter a grade: ");
                        Methods.AssignGrade(enrollmentToGrade, inputGrade);
                        break;

                    case 5: // View grades

                        Console.WriteLine();
                        if (!enrollments.Any())
                        {
                            Logger.Warning("No enrollments available. Enroll students before viewing grades.");
                            break;
                        }

                        var ViewGrades = Methods.ReadStudentId("Enter Student ID to view grades:");
                        var selectedStudent5 = students.FirstOrDefault(student => student.Id == (int)ViewGrades);

                        if (selectedStudent5 == null)
                        {
                            Logger.Error("Student not found. Please check the student ID and try again.");
                            break;
                        }

                        var enrollmentsView = enrollments.Where(e => e.Student == selectedStudent5).ToList();

                        if (!enrollmentsView.Any())
                        {
                            Logger.Warning($"{selectedStudent5.Name} has no enrollments yet.");
                            break;
                        }

                        foreach (var enrollment in enrollmentsView)
                        {
                            Methods.ViewGrade(enrollment);
                        }
                        break;

                    case 9: // Exit
                        Console.Clear();
                        Logger.Info("Thank you for using the School Management System. Goodbye!");
                        System.Threading.Thread.Sleep(2000);
                        isRunning = false;
                        break;

                    default:
                        Logger.Warning("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}