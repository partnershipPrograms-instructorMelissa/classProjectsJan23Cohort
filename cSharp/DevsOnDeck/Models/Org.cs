#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DevsOnDeck.Models;

public class Org {
    [Key]
    public int OrgId {get; set;}
    [Required]
    public string ContactName {get; set;}
    [Required]
    [EmailAddress]
    public string ContactEmail {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // ***** One to Many non id side
    public List<Job> JobList {get; set;} = new List<Job>();

    // ******** One to Many id side 
    public int UserId {get; set;}
    public User? theOrgCreator {get; set;}

    // ******* One to One non id side
    public OrgProfile? orgProf {get; set;}

    // ******* One to Many List side
    public List<OrgList> OrgMembers {get; set;} = new List<OrgList>();
}