#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DevsHelpingDevs.Models;

public class UserProfile {
    [Key]
    public int UserProfileId {get; set;}
    public string LinkedIn {get; set;} = " ";
    public string Github {get; set;} = " ";
    public string Bio {get; set;} = " ";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // **** Relationships ****
    public int UserId {get; set;}
    public User? myUser {get; set;}
}