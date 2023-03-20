#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DevsHelpingDevs.Models;

public class PassKey {
    [Key]
    public int PassKeyId {get; set;}
    public string PKey {get; set;}
    public DateTime LastUsed {get; set;} = DateTime.Now;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // **** Relationships ****

    public int UserId {get; set;}
    public User? userPass {get; set;}
}