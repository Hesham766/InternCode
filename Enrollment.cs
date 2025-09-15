namespace School_Management_System
{
    public class Enrollment
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
        public char Grade { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public Enrollment(Student student, Course course, char grade, DateTime enrollmentDate)
        {
            Student = student;
            Course = course;
            Grade = grade;
            EnrollmentDate = enrollmentDate = DateTime.Now;
        }
        
        override public string ToString()
        {
            return $"{Student.Name} enrolled in {Course.Title} with grade {Grade} on {EnrollmentDate}";
        }
    }
}