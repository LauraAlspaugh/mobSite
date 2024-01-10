namespace mobSite.Models;
public class Tier
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; }
    public int Cost { get; set; }
    public int ProjectId { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
}