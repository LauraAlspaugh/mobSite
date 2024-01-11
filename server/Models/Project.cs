namespace mobSite.Models;
public class Project
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; }
    public string Img { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
}