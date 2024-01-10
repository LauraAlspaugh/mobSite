
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
        throw new NotImplementedException();
    }
}