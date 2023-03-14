#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DevsOnDeck.Models;

public class Skill {
    [Key]
    public int SkillId {get; set;}
    // add more attributes here
    [Required]
    public string SkillName {get;set;}
    public string? SkillImg {get; set;}
    public string SkillType {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // **** Many to many list side

    public List<JobSkill> skilledJobs {get;set;} =  new List<JobSkill>();
    public List<DevSkill> skilledDevs {get;set;} = new List<DevSkill>();

}