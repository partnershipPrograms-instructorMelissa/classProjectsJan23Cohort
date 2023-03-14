#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DevsOnDeck.Models;

public class UserProfile {
    [Key]
    public int UserProfileId {get; set;}
    public string? Address {get; set;}
    public string City {get; set;}
    public string State {get; set;}
    public string Zip {get; set;}
    public string? Bio {get; set;}
    public string? LinkedIn {get; set;}
    public string? Github {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // ******* One to One id side
    public int UserId {get; set;}
    public User? owner {get; set;}

}