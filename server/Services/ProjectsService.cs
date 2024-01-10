

namespace mobSite.Services;
public class ProjectsService
{
    private readonly ProjectsRepository _projectsRepository;

    public ProjectsService(ProjectsRepository projectsRepository)
    {
        _projectsRepository = projectsRepository;
    }

    internal Project CreateProject(Project projectData)
    {
        Project project = _projectsRepository.CreateProject(projectData);
        return project;
    }

    internal List<Project> GetProjects()
    {
        List<Project> projects = _projectsRepository.GetProjects();
        return projects;
    }
}