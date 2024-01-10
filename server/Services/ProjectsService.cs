namespace mobSite.Services;
public class ProjectsService
{
    private readonly ProjectsRepository _projectsRepository;

    public ProjectsService(ProjectsRepository projectsRepository)
    {
        _projectsRepository = projectsRepository;
    }
}