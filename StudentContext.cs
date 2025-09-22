using School_Management_System;

public class StudentContext
{
    private IStudentServices _service;

    public StudentContext(IStudentServices service)
    {
        _service = service;
    }

    public void SetStrategy(IStudentServices service)
    {
        _service = service;
    }

    public void ExecuteStrategy(Student student, Course course)
    {
        _service.Execute(student, course);
    }
}