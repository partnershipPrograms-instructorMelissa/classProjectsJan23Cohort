#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DevsHelpingDevs.Models;

public class Org {
    [Key]
    public int OrgId {get; set;}
    public string Name {get; set;}
    public string Bio {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // **** Relationships ****

    public int UserId {get; set;}
    public User? owner {get; set;}
    public OrgProfile? myProfile {get; set;}
    public List<Job> ourJobs {get; set;}
}