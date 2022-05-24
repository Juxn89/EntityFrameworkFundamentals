using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace efFundamentals.Models;

public class Category {
    // [Key]
    public Guid Id {get; set;}

    // [Required]
    // [MaxLength(150)]
    public string Name {get; set;}
    public string Description {get; set;}
    public int Weight {get; set;}
    
    // Relations with models
    [JsonIgnore]
    public ICollection<Task> Tasks {get; set;}
}