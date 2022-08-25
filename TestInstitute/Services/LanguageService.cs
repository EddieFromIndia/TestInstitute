namespace TestInstitute.Services;

public class LanguageService
{
    private readonly ApplicationDbContext _context;

    public LanguageService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Language AddLanguage(LanguageVM language)
    {
        Language newLanguage = new()
        {
            Name = language.Name
        };

        EntityEntry<Language> lang = _context.Languages.Add(newLanguage);
        _context.SaveChanges();
        return lang.Entity;
    }

    public List<Language> GetAllLanguages() => _context.Languages.Include(l => l.Subjects_Languages).ToList();
    public List<Language> GetLanguagesBySubject(int subjectId) => _context.Subjects_Languages.Include(sl => sl.Subject).Include(sl => sl.Language).Where(sl => sl.SubjectId == subjectId).Select(sl => sl.Language).ToList();

    public Language? GetLanguageByName(string language) => GetAllLanguages().FirstOrDefault(l => l.Name == language);

    //public Language? GetLanguageById(int id) => GetAllLanguages().FirstOrDefault(l => l.Id == id);

    public bool LanguageExists(string language) => GetAllLanguages().Where(l => l.Name == language).Any();
}
