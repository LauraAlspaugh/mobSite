


using System.Threading;

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

    internal string DestroyProject(int projectId, string userId)
    {
        Project project = GetProjectById(projectId, userId);
        if (project.CreatorId != userId)
        {
            throw new Exception("don't even try it!");

        }
        _projectsRepository.DestroyProject(projectId);
        return "It really is gone.";
    }

    internal Project EditProject(int projectId, string id, Project projectData)
    {
        Project project = GetProjectById(projectId, id);
        if (project.CreatorId != id)
        {
            throw new Exception("not yours to edit!");
        }
        project.Name = projectData.Name ?? project.Name;
        project.Description = projectData.Description ?? project.Description;
        project.Img = projectData.Img ?? project.Img;
        project.Category = projectData.Category ?? project.Category;
        _projectsRepository.EditProject(project);
        return project;
    }

    internal Project GetProjectById(int projectId, string id)
    {
        Project project = _projectsRepository.GetProjectById(projectId);
        if (project == null)
        {
            throw new Exception("not a valid project id!");
        }
        return project;
    }

    internal List<Project> GetProjects()
    {
        List<Project> projects = _projectsRepository.GetProjects();
        return projects;
    }
}