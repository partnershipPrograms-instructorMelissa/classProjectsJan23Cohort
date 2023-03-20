#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DevsHelpingDevs.Models;

public class Skill {
    [Key]
    public int SkillId {get; set;}
    public string Name {get; set;}
    public string Type {get; set;}
    public string Img {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // **** Relationships ****
    public List<DevSkill> userSkills = new List<DevSkill>();
    public List<JobSkill> orgSkills = new List<JobSkill>();
}