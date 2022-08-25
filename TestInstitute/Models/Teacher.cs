namespace TestInstitute.Models;

public class Teacher
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Age { get; set; }
    public string Sex { get; set; } = default!;
    public string? Image { get; set; }

    // Navigation Properties
    public List<Subject>? Subjects { get; set; }
}
