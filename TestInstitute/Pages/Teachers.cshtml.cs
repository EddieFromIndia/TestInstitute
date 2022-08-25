namespace TestInstitute.Pages;

public class TeachersModel : PageModel
{
    private readonly TeacherService _teacherService;

    [BindProperty]
    public List<Teacher>? Teachers { get; set; } = new();

    public TeachersModel(TeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    public void OnGet()
    {
        Teachers = _teacherService.GetAllTeachers();
    }
}