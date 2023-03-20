#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DevsHelpingDevs.Models;

public class JobSkill {
    [Key]
    public int JobSkillId {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // **** Relationships ****
    public int JobId {get; set;}
    public Job? theJob {get; set;}
    public int SkillId {get; set;}
    public Skill? jobSkill {get; set;}
}