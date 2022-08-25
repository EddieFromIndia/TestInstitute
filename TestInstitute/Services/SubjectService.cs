namespace TestInstitute.Services;

public class SubjectService
{
    private readonly ApplicationDbContext _context;

    public SubjectService(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AddSubject(SubjectVM subject)
    {
        Subject newSubject = new()
        {
            Name = subject.Name,
            Class = int.Parse(subject.Class),
            TeacherId = subject.Teacher
        };

        _context.Subjects.Add(newSubject);
        _context.SaveChanges();

        foreach (int id in subject.LanguageIds)
        {
            Subject_Language _subject_language = new()
            {
                SubjectId = newSubject.Id,
                Subject = newSubject,
                LanguageId = id,
                Language = _context.Languages.FirstOrDefault(l => l.Id == id)!
            };
            _context.Subjects_Languages.Add(_subject_language);
            _context.SaveChanges();
        }
    }

    public List<Subject> GetAllSubjects() => _context.Subjects.Include(s => s.Subjects_Languages).Include(s => s.Teacher).ToList();
}
