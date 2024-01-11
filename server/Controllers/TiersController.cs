namespace mobSite.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TiersController : ControllerBase
{
    private readonly TiersService _tiersService;
    private readonly Auth0Provider _auth0Provider;

    public TiersController(TiersService tiersService, Auth0Provider auth0Provider)
    {
        _tiersService = tiersService;
        _auth0Provider = auth0Provider;
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Tier>> CreateTier([FromBody] Tier tierData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            tierData.CreatorId = userInfo.Id;
            Tier tier = _tiersService.CreateTier(tierData);
            return Ok(tier);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message); ;
        }
    }
}