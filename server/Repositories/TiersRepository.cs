

namespace mobSite.Repositories;
public class TiersRepository
{
    private readonly IDbConnection _db;

    public TiersRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Tier CreateTier(Tier tierData)
    {
        string sql = @"
       INSERT INTO tiers(name, cost, projectId, creatorId)
       VALUES(@Name, @Cost, @projectId, @CreatorId);

       SELECT 
    tie.*, 
    acc.*
    FROM tiers tie
    JOIN accounts acc ON acc.id = tie.creatorId
    WHERE tie.id = LAST_INSERT_ID();
    ";

        Tier tier = _db.Query<Tier, Account, Tier>(sql, (tier, account) =>
         {
             tier.Creator = account;
             return tier;
         }, tierData).FirstOrDefault();
        return tier;
    }

    internal List<Tier> GetTiersByProjectId(int projectId)
    {
        string sql = @"
    SELECT 
    tie.*, 
    acc.*
    FROM tiers tie
    JOIN accounts acc ON acc.id = tie.creatorId
    WHERE tie.projectId = @projectId;
    ";
        List<Tier> tiers = _db.Query<Tier, Account, Tier>(sql, (tier, account) =>
        {
            tier.Creator = account;
            return tier;
        }, new { projectId }).ToList();
        return tiers;
    }
}