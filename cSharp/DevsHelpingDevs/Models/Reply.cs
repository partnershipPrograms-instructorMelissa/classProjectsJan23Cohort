#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DevsHelpingDevs.Models;

public class Reply {
    [Key]
    public int ReplyId {get; set;}
    public string Content {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // **** Relationships ****
    public int UserId {get; set;}
    public User? replier {get; set;}
    public int Post {get; set;}
    public Post? forumPost {get; set;}
}