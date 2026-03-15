using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities;

public class Project : AuditableEntity
{
    private readonly List<TaskItem> _tasks = new();
    private readonly List<ProjectMember> _members = new();

    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = String.Empty;
    public IReadOnlyCollection<TaskItem> Tasks => _tasks;
    public IReadOnlyCollection<ProjectMember> Members => _members;

    private Project() { }

    public Project(string name, string description, Guid creaedBy)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Project name cannot be empty.", nameof(name));

        Name = name;
        Description = description;
        CreatedBy = creaedBy;
    }

    public void AddMember(Guid userId)
    {
        if (_members.Any(m => m.UserId == userId))
            return;

        _members.Add(new ProjectMember(Id, userId));
    }

    public void AddTask(TaskItem task)
    {
        _tasks.Add(task);
    }
}
