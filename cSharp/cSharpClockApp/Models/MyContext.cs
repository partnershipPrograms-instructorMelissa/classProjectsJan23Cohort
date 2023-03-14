#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace cSharpClockApp.Models;

public class MyContext : DbContext 
{    
    public MyContext(DbContextOptions options) : base(options) { }    
   
    public DbSet<User> Users { get; set; } 
    public DbSet<Skill> Skills {get; set;}
    public DbSet<UserSkills> UserSkillss {get; set;}
    public DbSet<Image> Images {get; set;}


}
