namespace mobSite.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly ProjectsService _projectsService;
    private readonly Auth0Provider _auth0Provider;

    public ProjectsController(ProjectsService projectsService, Auth0Provider auth0Provider)
    {
        _projectsService = projectsService;
        _auth0Provider = auth0Provider;
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
}