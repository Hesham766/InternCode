using School_Management_System;

public interface IStudentServices
{
    public string Execute(Student student, Course course);
}

// string Assign_View(Student student, Course course, char grade);
// void EnrollInCourse(Student student, Course course);
// void DropCourse(Student student, Course course);
// void AssignGrade(Student student, Course course, char grade);
// string ViewGrades(Student student, Course course, char grade);
// void DisplayEnrolledCourses(Student student, Course course);