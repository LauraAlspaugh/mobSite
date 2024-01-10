namespace mobSite.Repositories;
public class SupportsRepository
{
    private readonly IDbConnection _db;

    public SupportsRepository(IDbConnection db)
    {
        _db = db;
    }
}