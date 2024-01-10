
namespace mobSite.Repositories;
public class SupportsRepository
{
    private readonly IDbConnection _db;

    public SupportsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal List<Support> GetMySupports(string userId)
    {
        string sql = @"
    SELECT 
    sup.*,
    acc.*
    FROM supports sup
    JOIN accounts acc ON acc.id = sup.creatorId
    WHERE sup.creatorId = @userid;
    ";

        List<Support> supports = _db.Query<Support, Account, Support>(sql, (support, account) =>
        {
            support.Creator = account;
            return support;
        }, new { userId }).ToList();
        return supports;
    }
}