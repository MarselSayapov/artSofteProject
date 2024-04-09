namespace Domain.Entities;

public class User
{
    public required uint Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string Surname { get; set; }
    
    public required string Login { get; set; }
    
    public required string Password { get; set; }
}