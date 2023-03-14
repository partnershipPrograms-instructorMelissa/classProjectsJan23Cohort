#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace cSharpClockApp.Models;

public class Skill {
    [Key]
    public int SkillId {get; set;}
    public string Name {get; set;}
    public string Category {get; set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // ***** Many to Many List side
    public List<UserSkills> allSkills =  new List<UserSkills>();
}