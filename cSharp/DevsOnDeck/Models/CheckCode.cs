#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[NotMapped]
public class CheckCode
{
    [Required(ErrorMessage = "Organization Code Is Required")]
    public string CheckRKey {get; set;}
}