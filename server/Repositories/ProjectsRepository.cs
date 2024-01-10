

namespace mobSite.Repositories;
public class ProjectsRepository
{
    private readonly IDbConnection _db;

    public ProjectsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Project CreateProject(Project projectData)
    {
        string sql = @"
    INSERT INTO 
    projects(name, description, category, creatorId)
    VALUES(@Name, @Description, @Category, @CreatorId);
    SELECT 
    pro.*,
    acc.*
    FROM projects pro
    JOIN accounts acc ON pro.creatorId = acc.id
    WHERE pro.id = LAST_INSERT_ID();
";
        Project project = _db.Query<Project, Account, Project>(sql, (project, account) =>
        {
            project.Creator = account;
            return project;
        }, projectData).FirstOrDefault();
        return project;
    }

    internal List<Project> GetProjects()
    {
        string sql = @"
    SELECT 
    pro.*,
    acc.*
    FROM projects pro
    JOIN accounts acc ON pro.creatorId = acc.id
    ";
        List<Project> projects = _db.Query<Project, Account, Project>(sql, (project, account) =>
        {
            project.Creator = account;
            return project;
        }).ToList();
        return projects;
    }
}