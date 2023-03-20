#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DevsHelpingDevs.Models;

public class Post {
    [Key]
    public int PostId {get; set;}
    public string Title {get; set;}
    public string Content {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // **** Relationships ****
    public int UserId {get; set;}
    public User? poster {get; set;}
    public int Topic {get; set;}
    public Topic? forumTopic {get; set;}
    public List<Reply> postReplies {get; set;} = new List<Reply>();
}
