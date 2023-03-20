#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DevsHelpingDevs.Models;

public class Job {
    [Key]
    public int JobId {get; set;}
    public string Name {get; set;}
    public string Info {get; set;}
    public string Pay {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // **** Relationships ****
    public int OrgId {get; set;}
    public Org? orgPoster {get; set;}
}