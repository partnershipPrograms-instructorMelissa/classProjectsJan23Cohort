#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace cSharpClockApp.Models;

public class Image {
    [Key]
    public int ImageId {get; set;}
    public string Title {get; set;}
    public string Url {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // ***** One to Many Id side
    public int UserId {get; set;}
    public User? owner {get; set;}
}