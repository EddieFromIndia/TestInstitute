namespace TestInstitute.Models;

public class Subject
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Class { get; set; }

    // Navigation Properties
    public List<Subject_Language> Subjects_Languages { get; set; } = new();
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; } = default!;
}
