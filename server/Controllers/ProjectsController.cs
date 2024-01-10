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
}