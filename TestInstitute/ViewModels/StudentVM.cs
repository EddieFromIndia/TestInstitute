namespace TestInstitute.ViewModels
{
    public class StudentVM
    {
        public string Name { get; set; } = default!;
        public string Age { get; set; } = default!;
        [Display(Name = "Roll Number")]
        public string RollNumber { get; set; } = default!;
        public string Class { get; set; } = default!;
        public string? Sex { get; set; }
        public IFormFile? Image { get; set; }
    }
}
