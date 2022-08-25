namespace TestInstitute.Pages;

public class SubjectsModel : PageModel
{
    private readonly SubjectService _subjectService;
    private readonly StudentService _studentService;
    private readonly LanguageService _languageService;

    [BindProperty]
    public List<AllVM> All { get; set; } = new();

    public SubjectsModel(SubjectService subjectService, LanguageService languageService, StudentService studentService)
    {
        _subjectService = subjectService;
        _languageService = languageService;
        _studentService = studentService;
    }

    public void OnGet()
    {
        List<Subject> subjects = _subjectService.GetAllSubjects();
        List<Student> students = _studentService.GetAllStudents();

        foreach (Subject subject in subjects)
        {
            List<Student> studentsInClass = students.Where(s => s.Class == subject.Class).ToList();

            foreach (Student student in studentsInClass)
            {
                All.Add(new()
                {
                    Name = subject.Name,
                    Class = subject.Class,
                    Languages = string.Join(", ", _languageService.GetLanguagesBySubject(subject.Id).Select(l => l.Name)),
                    Student = student.Name,
                    Teacher = subject.Teacher.Name
                });
            }
        }
    }
}