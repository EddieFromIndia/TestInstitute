namespace TestInstitute.Services;

public class TeacherService
{
    private readonly ApplicationDbContext _context;

    public TeacherService(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AddTeacher(TeacherVM teacher)
    {
        Teacher newTeacher = new()
        {
            Name = teacher.Name,
            Age = int.Parse(teacher.Age),
            Sex = teacher.Sex,
            Image = ImageConverter.ToBase64(teacher.Image)
        };

        _context.Teachers.Add(newTeacher);
        _context.SaveChanges();
    }

    public List<Teacher> GetAllTeachers() => _context.Teachers.Include(t => t.Subjects).ToList();
}
