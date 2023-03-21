#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DevsHelpingDevs.Models;

public class User {
    [Key]
    public int UserId {get; set;}
    [Required]
    public string FirstName {get; set;}
    [Required]
    public string LastName {get; set;}
    [Required]
    public string Username {get; set;}
    [Required]
    public string Email {get; set;}
    [Required]
    public int Level {get; set;} = 0;
    public DateTime LastLogged {get; set;} = DateTime.Now;
    public string LastPage {get; set;} = "New";
    [Required]
    public string Password {get; set;}
    [NotMapped]
    [Compare("Password", ErrorMessage="Dang it passwords don't match try your luck again")]
    public string Confirm {get; set;}
    [NotMapped]
    [Required(ErrorMessage="Access to site is by invitation only please provide the code")]
    public string InviteCode {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // **** Relationships ****

    public UserProfile? myProfile {get; set;}
    public PassKey? myPassKey {get; set;}

    public List<Org> createdOrgs {get; set;} = new List<Org>();
    public List<DevSkill> mySkills {get; set;} = new List<DevSkill>();
    public List<Topic> myTopics {get; set;} = new List<Topic>();
    public List<Post> myPosts {get; set;} = new List<Post>();

    public string FullName() {
        return FirstName + " " + LastName;
    }
}