namespace mobSite.Models;
public class Post
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string Img { get; set; }
    public int ProjectId { get; set; }
    public int TierId { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
}