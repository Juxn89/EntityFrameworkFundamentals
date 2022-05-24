using efFundamentals.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace efFundamentals.Models;

public class Task {
    // [Key]
    public Guid Id {get; set;}

    // [ForeignKey("CategoryID")]
    public Guid CategoryId {get; set;}

    // [Required]
    // [MaxLength(200)]
    public string Title {get; set;}
    public string Description {get; set;}
    public Priority Priority {get; set;}
    public DateTime CreationDate {get; set;}

    [NotMapped]
    public string Summary {get; set;}

    // Relations with models
    public virtual Category Category {get; set;}
}