namespace mobSite.Repositories;
public class PostsRepository
{
    private readonly IDbConnection _db;

    public PostsRepository(IDbConnection db)
    {
        _db = db;
    }
}