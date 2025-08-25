using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Management_System;

namespace School_Management_System
{
    public class Enrollment
    {
        public Student Student { get;  set; }
        public Course Course { get;  set; }
        public char Grade { get; set; } 
        public DateTime DateEnrolled { get; private set; }

        public Enrollment(Student student, Course course, char Grade)
        {
            Student = student;
            Course = course;
            DateEnrolled = DateTime.Now;
            this.Grade = Grade;
        }

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
        }
    }
