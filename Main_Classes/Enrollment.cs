namespace School_Management_System
{
    public class Enrollment
    {
        public Student Student { get;  set; }
        public Course Course { get;  set; }
        public char Grade { get; set; } 
        public DateTime DateEnrolled { get; private set; }

        public Enrollment(Student student, Course course, char grade)
        {
            Student = student;
            Course = course;
            DateEnrolled = DateTime.Now;
            Grade = grade;
        }
    }
}