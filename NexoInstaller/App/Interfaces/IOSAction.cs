namespace McCreate.App.Interfaces;

public interface IOSAction
{
    public string Name { get; set; }
    
    public string SoftwareID { get; set; }
    
    public Task Execute(IServiceProvider serviceProvider);
}