using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities;

public class Comment : AuditableEntity
{
    public Guid TaskItemId { get; private set; }
    public string Content { get; private set; } = string.Empty;

    private Comment() { }

    public Comment(Guid taskItemId, string content, Guid createdBy)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Comment content cannot be empty.", nameof(content));

        TaskItemId = taskItemId;
        Content = content;
        CreatedBy = createdBy;
    }
}