namespace McCreate.App.Interfaces;

public interface IProgramAction
{
    public string Name { get; set; }
    
    public string ID { get; set; } 
    
    public Task Execute(IServiceProvider serviceProvider);
}