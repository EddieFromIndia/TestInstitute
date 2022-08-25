using System.IO;

namespace TestInstitute.Services;

public class StudentService
{
    private readonly ApplicationDbContext _context;

    public StudentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AddStudent(StudentVM student)
    {
        Student newStudent = new()
        {
            Name = student.Name,
            Age = int.Parse(student.Age),
            RollNumber = int.Parse(student.RollNumber),
            Class = int.Parse(student.Class),
            Sex = student.Sex,
            Image = ImageConverter.ToBase64(student.Image)
        };

        _context.Students.Add(newStudent);
        _context.SaveChanges();
    }

    public List<Student> GetAllStudents() => _context.Students.ToList();
}
