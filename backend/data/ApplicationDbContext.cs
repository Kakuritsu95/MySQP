using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext:DbContext 
  {
  public DbSet<User> Users {get;set;}
  public DbSet<Survey> Surveys {get;set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
        .HasMany(e=>e.Surveys)
        .WithOne(e=>e.Author)
        .HasForeignKey(e=>e.AuthorId).IsRequired();
        
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
    

