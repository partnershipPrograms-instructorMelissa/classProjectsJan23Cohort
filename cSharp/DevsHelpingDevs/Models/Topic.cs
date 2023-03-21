#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DevsHelpingDevs.Models;

public class Topic {
    [Key]
    public int TopicId {get; set;}
    public string Name {get; set;}
    public string Visibility {get; set;} = "Public";
    public string OrgTopic {get; set;} = "Open Topic";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // **** Relationships ****
    public int UserId {get; set;}
    public User? topicOwner {get; set;}
    public List<Post> topicPosts {get; set;} = new List<Post>();
}