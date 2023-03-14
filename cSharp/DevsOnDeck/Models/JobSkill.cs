#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DevsOnDeck.Models;

public class JobSkill {
    [Key]
    public int UserSkillId {get; set;}
    // add more attributes here
    public int? FrameOrder {get; set;} = 0;
    public int? LangOrder {get; set;} = 0;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int SkillId {get; set;}
    public Skill? theSkill {get; set;}
    public int JobId {get; set;}
    public Job? theJob {get; set;}
}