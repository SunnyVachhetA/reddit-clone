using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Abstract;
public abstract class AuditableEntity<T> : IdentityEntity<T>
{
    [Column("created_on")]
    public DateTimeOffset CreatedOn { get; set; }

    [Column("updated_on")]
    public DateTimeOffset UpdatedOn { get; set; }
}
