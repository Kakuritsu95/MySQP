using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext:DbContext 
  {
  public DbSet<User> Users {get;set;}
  public DbSet<Survey> Surveys {get;set;}
  public DbSet<Question> Questions {get;set;}
  public DbSet<Option> Options {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
        .HasMany(u=>u.Surveys)
        .WithOne(s=>s.Author)
        .HasForeignKey(s=>s.AuthorId).IsRequired();

        modelBuilder.Entity<Survey>()
        .HasMany(s=>s.Questions)
        .WithOne(q=>q.Survey)        
        .HasForeignKey(q=>q.SurveyId).IsRequired();
        
        modelBuilder.Entity<Survey>()
        .HasMany(s=>s.Submissions)
        .WithOne(s=>s.Survey)
        .HasForeignKey(s=>s.SurveyId).IsRequired();

        modelBuilder.Entity<Question>()
        .HasMany(q=>q.Options)
        .WithOne(o=>o.Question)
        .HasForeignKey(o=>o.QuestionId).IsRequired();

        modelBuilder.Entity<Question>()
        .HasMany(q=>q.Answers)
        .WithOne(a=>a.Question)
        .HasForeignKey(a=>a.QuestionId).IsRequired();

        modelBuilder.Entity<Submission>()
        .HasMany(s=>s.Answers)
        .WithOne(a=>a.Submission)
        .HasForeignKey(a=>a.SubmissionId).IsRequired();
        
        modelBuilder.Entity<Survey>()
            .Property(s => s.SurveyType)
            .HasConversion<string>();
    }

    public override Task<int> SaveChangesAsync(
    bool acceptAllChangesOnSuccess,
    CancellationToken token = default)
{
    foreach (var entity in ChangeTracker
        .Entries()
        .Where(x => x.Entity is BaseEntity && x.State == EntityState.Modified)
        .Select(x => x.Entity)
        .Cast<BaseEntity>())
    {
        entity.UpdatedAt = DateTime.Now;
    }

    return base.SaveChangesAsync(acceptAllChangesOnSuccess, token);
}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
  {
    
  }
   


}
    

