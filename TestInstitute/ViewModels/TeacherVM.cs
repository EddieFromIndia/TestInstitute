namespace TestInstitute.ViewModels;

public class TeacherVM
{
    public string Name { get; set; } = default!;
    public string Age { get; set; } = default!;
    public string Sex { get; set; } = default!;
    public IFormFile? Image { get; set; }
}
