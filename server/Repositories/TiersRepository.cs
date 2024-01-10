namespace mobSite.Repositories;
public class TiersRepository
{
    private readonly IDbConnection _db;

    public TiersRepository(IDbConnection db)
    {
        _db = db;
    }
}