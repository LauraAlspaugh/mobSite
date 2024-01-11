



namespace mobSite.Repositories;
public class PostsRepository
{
    private readonly IDbConnection _db;

    public PostsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Post CreatePost(Post postData)
    {
        string sql = @"
    INSERT INTO 
    posts(title, body, projectId, tierId, creatorId)
    VALUES(@Title, @Body, @ProjectId, @TierId, @CreatorId);
    SELECT 
    pos.*,
    acc.*
    FROM posts pos
    JOIN accounts acc ON pos.creatorId = acc.id
    WHERE pos.id = LAST_INSERT_ID();
";
        Post post = _db.Query<Post, Account, Post>(sql, (post, account) =>
        {
            post.Creator = account;
            return post;
        }, postData).FirstOrDefault();
        return post;
    }

    internal void DestroyPost(int postId)
    {

        string sql = @"
      DELETE FROM posts
      WHERE id = @postId LIMIT 1;
      SELECT pos.*,
      acc.*
      FROM posts pos
      JOIN accounts acc ON pos.creatorId = acc.id
      WHERE pos.id = @postId;
      ";
        _db.Execute(sql, new { postId });
    }

    internal Post GetPostById(int postId)
    {
        string sql = @"
       SELECT 
       pos.*,
       acc.*
       FROM posts pos
       JOIN accounts acc ON pos.creatorId = acc.id
       WHERE pos.id = @postId;
       ";
        Post post = _db.Query<Post, Account, Post>(sql, (post, account) =>
        {
            post.Creator = account;
            return post;
        }, new { postId }).FirstOrDefault();
        return post;
    }

    internal List<Post> GetPostsByProjectId(int projectId)
    {
        string sql = @"
    SELECT 
    pos.*, 
    acc.*
    FROM posts pos
    JOIN accounts acc ON acc.id = pos.creatorId
    WHERE pos.projectId = @projectId;
    ";
        List<Post> posts = _db.Query<Post, Account, Post>(sql, (post, account) =>
        {
            post.Creator = account;
            return post;
        }, new { projectId }).ToList();
        return posts;
    }
}