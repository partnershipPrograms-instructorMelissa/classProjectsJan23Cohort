#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace DevsOnDeck.Models;

public class MyContext : DbContext 
{    
    public MyContext(DbContextOptions options) : base(options) { }    
   
    public DbSet<User> Users { get; set; } 
    public DbSet<UserProfile> UserProfiles {get; set;}
    public DbSet<RandKey> RandKeys {get; set;}
    public DbSet<Dev> Devs {get; set;}
    public DbSet<DevSkill> DevSkills {get; set;}
    public DbSet<Skill> Skills {get;set;}
    public DbSet<JobSkill> JobSkills {get; set;}
    public DbSet<Job> Jobs {get;set;}
    public DbSet<Org> Orgs {get;set;}
    public DbSet<OrgProfile> OrgProfiles {get; set;}
    public DbSet<OrgList> OrgLists {get;set;}

}