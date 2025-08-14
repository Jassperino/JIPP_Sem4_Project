using JIPP_Projekt_Sem4.Models;
using JIPP_Projekt_Sem4.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JIPP_Projekt.Data;

public class SchoolDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        
        string connectionString =
            "Data Source=127.0.0.1,1433;Initial Catalog=JiPP_Projekt;User Id=sa;Password=JiPP4@Passw0rd;Encrypt=False;TrustServerCertificate=True;";
        optionsBuilder.UseSqlServer(connectionString, sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(3);
        });
    }
    
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserGroup> UserGroups { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserGroupConfiguration());
    }
}    