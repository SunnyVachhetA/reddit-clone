using System.ComponentModel.DataAnnotations;

namespace Entities.Abstract;
public abstract class IdentityEntity<T>
{
    [Key]
    public T Id { get; set; }
}
