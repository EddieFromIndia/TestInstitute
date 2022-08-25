namespace TestInstitute.Pages;

public class IndexModel : PageModel
{
    private readonly StudentService _studentService;

    [BindProperty]
    public StudentVM Student { get; set; } = new();

    public IndexModel(StudentService studentService)
    {
        _studentService = studentService;
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

        _studentService.AddStudent(Student);

        return RedirectToPage("/Students");
    }
}