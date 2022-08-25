namespace TestInstitute.Models;

public class Subject_Language
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }

    public int SubjectId { get; set; }
    public Subject Subject { get; set; } = new();

    public int LanguageId { get; set; }
    public Language Language { get; set; } = new();
}
