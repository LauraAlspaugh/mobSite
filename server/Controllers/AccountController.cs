namespace mobSite.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly SupportsService _supportsService;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, SupportsService supportsService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _supportsService = supportsService;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [Authorize]
  [HttpGet("supports")]
  public async Task<ActionResult<List<Support>>> GetMySupports()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string userId = userInfo.Id;
      List<Support> supports = _supportsService.GetMySupports(userId);
      return Ok(supports);
    }
    catch (Exception error)
    {

      return BadRequest(error.Message);
    }
  }
}
