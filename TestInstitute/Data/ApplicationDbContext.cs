using TestInstitute.Models;

namespace TestInstitute.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Student> Students { get; set; } = default!;
    public DbSet<Teacher> Teachers { get; set; } = default!;
    public DbSet<Subject> Subjects { get; set; } = default!;
    public DbSet<Language> Languages { get; set; } = default!;
    public DbSet<Subject_Language> Subjects_Languages { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Subject_Language>().HasOne(sl => sl.Subject).WithMany(sl => sl.Subjects_Languages).HasForeignKey(sl => sl.SubjectId);
        modelBuilder.Entity<Subject_Language>().HasOne(sl => sl.Language).WithMany(sl => sl.Subjects_Languages).HasForeignKey(sl => sl.LanguageId);
    }
}
