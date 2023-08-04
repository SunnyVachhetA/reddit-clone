namespace Entities.Abstract;
public abstract class AuditableEntity<T> : IdentityEntity<T>
{
    public DateTimeOffset CreatedOn { get; set; }

    public DateTimeOffset UpdatedOn { get; set; }
}
