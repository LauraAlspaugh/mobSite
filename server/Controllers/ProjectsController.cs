namespace mobSite.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly ProjectsService _projectsService;
    private readonly Auth0Provider _auth0Provider;
    private readonly TiersService _tiersService;
    private readonly PostsService _postsService;
    private readonly SupportsService _supportsService;

    public ProjectsController(ProjectsService projectsService, Auth0Provider auth0Provider, TiersService tiersService, PostsService postsService, SupportsService supportsService)
    {
        _projectsService = projectsService;
        _auth0Provider = auth0Provider;
        _tiersService = tiersService;
        _postsService = postsService;
        _supportsService = supportsService;
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Project>> CreateProject([FromBody] Project projectData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            projectData.CreatorId = userInfo.Id;
            Project project = _projectsService.CreateProject(projectData);
            return Ok(project);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpGet]
    public ActionResult<List<Project>> GetProjects()
    {
        try
        {
            List<Project> projects = _projectsService.GetProjects();
            return Ok(projects);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpGet("{projectId}")]
    public async Task<ActionResult<Project>> GetProjectById(int projectId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            Project project = _projectsService.GetProjectById(projectId, userInfo.Id);
            return Ok(project);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [Authorize]
    [HttpPut("{projectId}")]
    public async Task<ActionResult<Project>> EditProject(int projectId, [FromBody] Project projectData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            Project project = _projectsService.EditProject(projectId, userInfo.Id, projectData);
            return Ok(project);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [Authorize]
    [HttpDelete("{projectId}")]
    public async Task<ActionResult<string>> DestroyProject(int projectId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string userId = userInfo.Id;
            string message = _projectsService.DestroyProject(projectId, userId);
            return Ok(message);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpGet("{projectId}/tiers")]
    public ActionResult<List<Tier>> GetTiersByProjectId(int projectId)
    {
        try
        {
            List<Tier> tiers = _tiersService.GetTiersByProjectId(projectId);
            return Ok(tiers);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpGet("{projectId}/posts")]
    public ActionResult<List<Post>> GetPostsByProjectId(int projectId)
    {
        try
        {
            List<Post> posts = _postsService.GetPostsByProjectId(projectId);
            return Ok(posts);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpGet("{projectId}/supports")]
    public ActionResult<List<Support>> GetSupportsByProjectId(int projectId)
    {
        try
        {
            List<Support> supports = _supportsService.GetSupportsByProjectId(projectId);
            return Ok(supports);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }

}