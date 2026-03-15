namespace TaskFlow.Domain.Common;

public abstract class AuditableEntity : BaseEntity
{
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
    public Guid CreatedBy { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }
    public Guid? UpdatedBy { get; protected set; }

    public void SetUpdated(Guid userId)
    { 
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = userId;
    }
}
