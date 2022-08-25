namespace TestInstitute.Models;

public class Language
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    // Navigation Properties
    public List<Subject_Language> Subjects_Languages { get; set; } = new();
}
