#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DevsHelpingDevs.Models;

public class OrgProfile {
    [Key]
    public int OrgProfileId {get; set;}
    public string OrgOwner {get; set;}
    public string Location {get; set;}
    public string Email {get; set;}
    public string Phone {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // **** Relationships ****

    public int OrgId {get; set;}
    public Org? myOrg {get; set;}
}