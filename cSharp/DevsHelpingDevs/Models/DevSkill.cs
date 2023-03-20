#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DevsHelpingDevs.Models;

public class DevSkill {
    [Key]
    public int DevSkillId {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // **** Relationships ****
    public int UserId {get; set;}
    public User? theUser {get; set;}
    public int SkillId {get; set;}
    public Skill? mySkill {get; set;}

}