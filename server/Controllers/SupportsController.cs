namespace mobSite.Controllers;
[ApiController]
[Route("api/[controller]")]
public class SupportsController : ControllerBase
{
    private readonly SupportsService _supportsService;
    private readonly Auth0Provider _auth0Provider;

    public SupportsController(SupportsService supportsService, Auth0Provider auth0Provider)
    {
        _supportsService = supportsService;
        _auth0Provider = auth0Provider;
    }
}