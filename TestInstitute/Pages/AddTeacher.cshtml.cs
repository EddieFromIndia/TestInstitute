namespace TestInstitute.Pages;

public class AddTeacherModel : PageModel
{
    private readonly TeacherService _teacherService;

    [BindProperty]
    public TeacherVM Teacher { get; set; } = new();

    public AddTeacherModel(TeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    public void OnGet()
    {

    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
        {
            return Page();
        }

        _teacherService.AddTeacher(Teacher);

        return RedirectToPage("/Teachers");
    }
}