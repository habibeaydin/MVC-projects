namespace CourseApp.Models;

public static class Repository
{
    private static List<Student> applications = new();
    public static IEnumerable<Student> Applications => applications;

    public static void Add(Student student)
    {
        applications.Add(student);
    }
}