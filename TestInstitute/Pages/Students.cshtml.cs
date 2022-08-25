namespace TestInstitute.Pages;

public class StudentsModel : PageModel
{
    private readonly StudentService _studentService;

    [BindProperty]
    public List<Student>? Students { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? SearchText { get; set; }

    public StudentsModel(StudentService studentService)
    {
        _studentService = studentService;
    }

    public void OnGet()
    {
        Students = _studentService.GetAllStudents();

        if (!string.IsNullOrEmpty(SearchText))
        {
            Students = Students.Where(s => s.Name.ToLower().Contains(SearchText.Trim().ToLower())).ToList();
        }
    }
}