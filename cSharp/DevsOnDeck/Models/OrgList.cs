#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DevsOnDeck.Models;

public class OrgList {
    [Key]
    public int OrgListId {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // *******  Many to Many allowing users to be apart of many orgs
    public int UserId {get; set;}
    public User? theUser {get; set;}
    public int OrgId {get;set;}
    public Org? theOrg {get;set;}
}