using Microsoft.Extensions.Caching.Memory;

namespace TestInstitute.Pages;

public class AddSubjectModel : PageModel
{
    private readonly SubjectService _subjectService;
    private readonly LanguageService _languageService;
    private readonly TeacherService _teacherService;

    [BindProperty]
    public SubjectVM Subject { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public List<Teacher> Teachers { get; set; } = new();

    [BindProperty]
    public int SelectedTeacher { get; set; }

    [BindProperty]
    public string? Languages { get; set; }

    public AddSubjectModel(SubjectService subjectService, LanguageService languageService, TeacherService teacherService)
    {
        _subjectService = subjectService;
        _languageService = languageService;
        _teacherService = teacherService;
    }

    public void OnGet()
    {
        Teachers = _teacherService.GetAllTeachers();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
        {
            Teachers = _teacherService.GetAllTeachers();
            return Page();
        }

        Subject.Teacher = SelectedTeacher;

        if (!string.IsNullOrWhiteSpace(Languages))
        {
            List<string> languages = Languages.Replace(", ", ",").TrimEnd(',').Split(",").ToList();

            foreach (string language in languages)
            {
                Subject.LanguageIds.Add(_languageService.LanguageExists(language) ?
                    (_languageService.GetLanguageByName(language)!).Id :
                    _languageService.AddLanguage(new() { Name = language }).Id);
            }
        }

        _subjectService.AddSubject(Subject);

        return RedirectToPage("/Subjects");
    }
}