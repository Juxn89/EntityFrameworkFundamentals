namespace efFundamentals.Models;

public class Category {
    public Guid Id {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
    
    // Relations with models
    public ICollection<Task> Tasks {get; set;}
}