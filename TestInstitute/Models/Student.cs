namespace TestInstitute.Models;

public class Student
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Age { get; set; }
    public int RollNumber { get; set; }
    public int Class { get; set; }
    public string? Sex { get; set; }
    public string? Image { get; set; }
}
