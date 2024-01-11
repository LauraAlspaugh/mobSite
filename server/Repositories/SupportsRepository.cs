


namespace mobSite.Repositories;
public class SupportsRepository
{
    private readonly IDbConnection _db;

    public SupportsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Support CreateSupport(Support supportData)
    {
        string sql = @"
    INSERT INTO 
    supports(projectId, tierId, creatorId)
    VALUES(@ProjectId, @TierId, @CreatorId);
    SELECT 
    sup.*,
    acc.*
    FROM supports sup
    JOIN accounts acc ON sup.creatorId = acc.id
    WHERE sup.id = LAST_INSERT_ID();
";
        Support support = _db.Query<Support, Account, Support>(sql, (support, account) =>
         {
             support.Creator = account;
             return support;
         }, supportData).FirstOrDefault();
        return support;
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

    internal List<Support> GetSupportsByProjectId(int projectId)
    {
        string sql = @"
    SELECT 
    sup.*, 
    acc.*
    FROM supports sup
    JOIN accounts acc ON acc.id = sup.creatorId
    WHERE sup.projectId = @projectId;
    ";
        List<Support> supports = _db.Query<Support, Account, Support>(sql, (support, account) =>
        {
            support.Creator = account;
            return support;
        }, new { projectId }).ToList();
        return supports;
    }
}