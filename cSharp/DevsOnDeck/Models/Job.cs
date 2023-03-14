#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DevsOnDeck.Models;

public class Job {
    [Key]
    public int JobId {get; set;}
    public string JobTitle {get; set;}
    public string Info {get; set;}
    public string YearlyPay {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // ***** Many to Many non id side

    public List<JobSkill> theJobSkills {get; set;} = new List<JobSkill>();

    // ****** One to Many id side
    public int OrgId {get; set;}
    public Org? theOrg {get; set;}

}