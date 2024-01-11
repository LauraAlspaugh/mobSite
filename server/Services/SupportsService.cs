


namespace mobSite.Services;
public class SupportsService
{
    private readonly SupportsRepository _supportsRepository;

    public SupportsService(SupportsRepository supportsRepository)
    {
        _supportsRepository = supportsRepository;
    }

    internal Support CreateSupport(Support supportData)
    {
        Support support = _supportsRepository.CreateSupport(supportData);
        return support;
    }

    internal List<Support> GetMySupports(string userId)
    {
        List<Support> supports = _supportsRepository.GetMySupports(userId);
        supports = supports.FindAll(support => support.CreatorId == userId);
        return supports;
    }

    internal List<Support> GetSupportsByProjectId(int projectId)
    {
        List<Support> supports = _supportsRepository.GetSupportsByProjectId(projectId);
        return supports;
    }
}