using System;

public class ConsoleLogs
{
    public void MainMenu()
    {
        Console.WriteLine("\n");
        Console.WriteLine("===  ============================ ===");
        Console.WriteLine("===    School_Management_System   ===");
        Console.WriteLine("===  ============================ ===");
        Console.WriteLine("===  (1) Enroll Course            ===");
        Console.WriteLine("===  (2) Drop Course              ===");
        Console.WriteLine("===  (3) View Enrolled Courses    ===");
        Console.WriteLine("===  (4) Assign Grade             ===");
        Console.WriteLine("===  (5) View Grades              ===");
        Console.WriteLine("===  (9) Exit                     ===");
        Console.WriteLine("===  ============================ ===");
        Console.Write("\nEnter Your Choice: ");
    }

    public void CoursesList()
    {
        Console.WriteLine("============== Courses ==================");
        Console.WriteLine(" Name: Calculus I -------- Code: MAT101");
        Console.WriteLine(" Name: Physics I  -------- Code: PHY101");
        Console.WriteLine(" Name: Stats&Prob -------- Code: STA101");
        Console.WriteLine(" Name: Intro_to_Prog ----- Code: CSE101");
        Console.WriteLine(" Name: Data Structures --- Code: DSA101");
        Console.WriteLine("=========================================");
    }

    public void GradesList()
    {
        Console.WriteLine("============== Grades ================");
        Console.WriteLine("   A --------------------> excellent");
        Console.WriteLine("   B --------------------> very good");
        Console.WriteLine("   C --------------------> good");
        Console.WriteLine("   D --------------------> pass");
        Console.WriteLine("   F --------------------> fail");
        Console.WriteLine("======================================");
    }
}