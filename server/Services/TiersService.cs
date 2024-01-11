

namespace mobSite.Services;
public class TiersService
{
    private readonly TiersRepository _tiersRepository;

    public TiersService(TiersRepository tiersRepository)
    {
        _tiersRepository = tiersRepository;
    }

    internal Tier CreateTier(Tier tierData)
    {
        Tier tier = _tiersRepository.CreateTier(tierData);
        return tier;
    }

    internal List<Tier> GetTiersByProjectId(int projectId)
    {
        List<Tier> tiers = _tiersRepository.GetTiersByProjectId(projectId);
        return tiers;
    }
}