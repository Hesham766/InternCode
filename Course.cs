namespace School_Management_System
{
    public class Course
    {
        public int Id { get; set; }
        private string code = string.Empty;
        public string Code
        {
            get { return code; }
            set
            {
                // A course code must follow the format ABC123
                while (true)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(value, @"^[A-Z]{3}\d{3}$"))
                    {
                        code = value;
                        break;
                    }
                    Console.WriteLine("Invalid code format. The correct format is: ABC123");
                    value = Console.ReadLine() ?? string.Empty;
                }
            }
        }

        public string Title { get; set; }
        public int Credits { get; set; }

        public List<Student> EnrolledStudents { get; set; } = new List<Student>();

        public Course(int id, string code, string title, int credits)
        {
            Id = id;
            Code = code;
            Title = title;
            Credits = credits;
        }
    }
}