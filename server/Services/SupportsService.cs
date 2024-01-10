
namespace mobSite.Services;
public class SupportsService
{
    private readonly SupportsRepository _supportsRepository;

    public SupportsService(SupportsRepository supportsRepository)
    {
        _supportsRepository = supportsRepository;
    }

    internal List<Support> GetMySupports(string userId)
    {
        List<Support> supports = _supportsRepository.GetMySupports(userId);
        supports = supports.FindAll(support => support.CreatorId == userId);
        return supports;
    }
}