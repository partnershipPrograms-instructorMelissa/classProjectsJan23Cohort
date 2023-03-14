#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DevsOnDeck.Models;

public class RandKey {
    [Key]
    public int RandKeyId {get; set;}
    public string RKey {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // ******* One to One non id side
    public int UserId {get; set;}
    public User? adminUser {get; set;}
}