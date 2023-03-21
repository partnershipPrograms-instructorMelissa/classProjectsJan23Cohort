#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[NotMapped]
public class CheckCode
{
    [Required(ErrorMessage = "Code Is Required")]
    public string CheckRKey {get; set;}
}