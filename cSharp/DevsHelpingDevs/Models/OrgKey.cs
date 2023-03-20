#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DevsHelpingDevs.Models;

public class OrgKey {
    [Key]
    public int OrgKeyId {get; set;}
    public string OKey {get; set;}
    public DateTime LastUsed {get; set;} = DateTime.Now;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // **** Relationships ****
    
}