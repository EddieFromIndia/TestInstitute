namespace TestInstitute.ViewModels;

public class SubjectVM
{
    public string Name { get; set; } = default!;
    public string Class { get; set; } = default!;

    public List<int> LanguageIds { get; set; } = new();
    public int Teacher { get; set; }
}
