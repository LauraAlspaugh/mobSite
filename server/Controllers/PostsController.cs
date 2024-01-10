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
}