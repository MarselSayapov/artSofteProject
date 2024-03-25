namespace domain.Entities;

public partial record SuggestedUser
{
    public required uint UserId { get; set; }
    
    public required string About { get; set; }
    
    public required int Age { get; set; }
    
    public required string PhotoId { get; set; }
}

public partial record SuggestedUser
{
    
}