#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace cSharpClockApp.Models;

public class UserSkills {
    [Key]
    public int UserSkillsId {get; set;}
    public string Proficiency {get; set;}
    public DateTime LearnDate {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // ***** Many to Many - ID side
    public int UserId {get; set;}
    public User? owner {get; set;}
    public int SkillId {get; set;}
    public Skill? aSkill {get; set;}
}