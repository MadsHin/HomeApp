using HomeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Infrastructure.Persistance;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Contact> Contacts {get; set;} 
    public DbSet<FamilyMember> FamilyMembers {get; set;}
    public DbSet<HomeProject> HomeProjects {get; set;}
    public DbSet<HomeProjectContact> HomeProjectContacts {get; set;}
    public DbSet<HomeProjectMaterial> HomeProjectMaterials {get; set;}
    public DbSet<HouseholdTask> HouseholdTasks {get; set;}
    public DbSet<Material> Materials {get; set;}
    public DbSet<Photo> Photos {get; set;}
    public DbSet<ProgressEntry> ProgressEntries {get; set;}
    public DbSet<ProjectLink> ProjectLinks {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HomeProjectContact>()
            .HasKey(x => new { x.HomeProjectId, x.ContactId});

        modelBuilder.Entity<HomeProjectMaterial>()
            .HasKey(x => new { x.HomeProjectId, x.MaterialId});
    }
}