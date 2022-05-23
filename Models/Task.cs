using efFundamentals.enums;

namespace efFundamentals.Models;

public class Task {
    public Guid Id {get; set;}
    public Guid CategoryId {get; set;}
    public string Title {get; set;}
    public string Description {get; set;}
    public Priority Priority {get; set;}
    public DateTime CreationDate {get; set;}

    // Relations with models
    public virtual Category Category {get; set;}
}