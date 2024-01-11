




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
    projects(name, img, description, category, creatorId)
    VALUES(@Name, @Img, @Description, @Category, @CreatorId);
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

    internal void DestroyProject(int projectId)
    {
        string sql = @"
      DELETE FROM projects 
      WHERE id = @projectId LIMIT 1;
      SELECT pro.*,
      acc.*
      FROM projects pro
      JOIN accounts acc ON pro.creatorId = acc.id
      WHERE pro.id = @projectId;
      ";
        _db.Execute(sql, new { projectId });
    }

    internal Project EditProject(Project project)
    {
        string sql = @"
        UPDATE projects
        SET 
        name = @Name,
        description = @Description,
        category = @Category
        WHERE id = @Id;

        SELECT 
        pro.*,
        acc.*
        FROM projects pro
        JOIN accounts acc ON pro.creatorId = acc.id
        WHERE pro.id = @Id;
        ";

        Project newProject = _db.Query<Project, Account, Project>(sql, (project, account) =>
        {
            project.Creator = account;
            return project;
        }, project).FirstOrDefault();
        return newProject;
    }

    internal Project GetProjectById(int projectId)
    {
        string sql = @"
       SELECT 
       pro.*,
       acc.*
       FROM projects pro
       JOIN accounts acc ON pro.creatorId = acc.id
       WHERE pro.id = @projectId;
       ";
        Project project = _db.Query<Project, Account, Project>(sql, (project, account) =>
        {
            project.Creator = account;
            return project;
        }, new { projectId }).FirstOrDefault();
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