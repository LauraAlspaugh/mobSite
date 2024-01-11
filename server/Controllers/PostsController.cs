namespace mobSite.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly PostsService _postsService;
    private readonly Auth0Provider _auth0Provider;

    public PostsController(PostsService postsService, Auth0Provider auth0Provider)
    {
        _postsService = postsService;
        _auth0Provider = auth0Provider;
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost([FromBody] Post postData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            postData.CreatorId = userInfo.Id;
            Post post = _postsService.CreatePost(postData);
            return Ok(post);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [Authorize]
    [HttpDelete("{postId}")]
    public async Task<ActionResult<string>> DestroyPost(int postId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string userId = userInfo.Id;
            string message = _postsService.DestroyPost(postId, userId);
            return Ok(message);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpGet("{postId}")]
    public ActionResult<Post> GetPostById(int postId)
    {
        try
        {

            Post post = _postsService.GetPostById(postId);
            return Ok(post);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
}