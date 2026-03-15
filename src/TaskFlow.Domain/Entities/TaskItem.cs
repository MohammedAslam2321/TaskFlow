using System.Globalization;
using TaskFlow.Domain.Common;
using TaskFlow.Domain.Enums;
using TaskStatus = TaskFlow.Domain.Enums.TaskStatus;

namespace TaskFlow.Domain.Entities;

public class TaskItem : AuditableEntity
{
    private readonly List<Comment> _comments = new();

    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public Guid ProjectId { get; private set; }
    public Guid AssignedTo { get; private set; }
    public DateTime? DueDate { get; private set; }
    public TaskStatus Status { get; private set; } = TaskStatus.Todo;
    public IReadOnlyCollection<Comment> Comments => _comments;

    private TaskItem() { }

    public TaskItem(string title, string description, Guid createdBy)
    {
        Title = title;
        Description = description;
        CreatedBy = createdBy;
    }

    public void AssignUser(Guid userId)
    { 
        AssignedTo = userId;
    }

    public void UpdateStatus(TaskStatus newStatus)
    {
        Status = newStatus;
    }

    public void AddComment(Comment comment)
    { 
        _comments.Add(comment);
    }
}