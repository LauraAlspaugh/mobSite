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
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Support>> CreateSupport([FromBody] Support supportData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            supportData.CreatorId = userInfo.Id;
            Support support = _supportsService.CreateSupport(supportData);
            return Ok(support);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
}